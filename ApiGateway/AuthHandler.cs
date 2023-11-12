using System.IdentityModel.Tokens.Jwt;

namespace ApiGateway;

public class AuthHandler
{
    private readonly RequestDelegate next;

    public AuthHandler(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        var token = context.Request.Headers["Authorization"].ToString();
        if (string.IsNullOrEmpty(token) || !CheckTokenIsValid(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await next(context);
    }
    public static long GetTokenExpirationTime(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(token);
        var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
        var ticks = long.Parse(tokenExp);
        return ticks;
    }

    public static bool CheckTokenIsValid(string token)
    {
        var tokenTicks = GetTokenExpirationTime(token);
        var tokenDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

        var now = DateTime.Now.ToUniversalTime();

        var valid = tokenDate >= now;

        return valid;
    }
}
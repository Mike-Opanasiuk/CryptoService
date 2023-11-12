using ApiGateway;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using Shared.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddBearer(builder.Configuration.GetValue<string>("Jwt:Secret"));

builder.Services.AddOcelot();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<AuthHandler>();
app.UseOcelot().Wait();

app.Run();

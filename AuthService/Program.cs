using Application;
using Application.Features.AccountFeatures.Services;
using AuthService;
using AuthService.Extensions;
using AuthService.Extentions;
using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shared.CustomMiddlewares.ExceptionHandlingMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<UserEntity, RoleEntity>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddBearer(builder.Configuration.GetValue<string>("Jwt:Secret"));
builder.Services.AddScoped<JwtService>();

builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(MediatrAssemblyReference).Assembly));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
        // to ingore loop inside entities that reference each other
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


builder.Services.AddSwaggerGen(c =>
{
    // First we define the security scheme
    c.AddSecurityDefinition(
        "Bearer", // Name the security scheme
        new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Type = SecuritySchemeType.Http, // We set the scheme type to http since we're using bearer authentication
            Scheme = "bearer" // The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
        });

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
    });
});

var app = builder.Build();

app.UseSeed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

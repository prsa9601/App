using AngleSharp;
using App.Infrastructure.JwtUtil;
using AspNetCoreRateLimit;
using Shop.Api.Infrastructure;
using Shop.Api.Infrastructure.Gateways.Zibal;
using AutoMapper;
//using Shop.Api.Infrastructure.JwtUtil;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace App.Infrastructure;

public static class DependencyRegister
{
    public static void RegisterApiDependency(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddAutoMapper(typeof(MapperProfile).Assembly);
        service.AddTransient<CustomJwtValidation>();
        service.AddHttpClient<IZibalService, ZibalService>();

        service.AddCors(options =>
        {
            options.AddPolicy(name: "ShopApi",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
        service.AddMemoryCache();

        //load general configuration from appsettings.json
        service.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

        //load ip rules from appsettings.json
        service.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

        // inject counter and rules stores
        service.AddInMemoryRateLimiting();

        service.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    }
}
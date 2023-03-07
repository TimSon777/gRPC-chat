using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class JwrBearerAuthenticationConfiguration
{
    public static IServiceCollection AddJwrBearerAuthentication(this IServiceCollection services,
        JwtSettings jwtSettings)
    {
        var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience
                };
            });

        return services;
    }
}
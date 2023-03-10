using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Server.Abstractions;
using Server.Models;

namespace Server.Implementations;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtSettings _jwtSettings;

    public JwtProvider(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }

    public JwtResponse Generate(JwtRequest request)
    {
        var utcNow = DateTime.UtcNow;

        var jwt = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            notBefore: utcNow,
            expires: utcNow.AddYears(1),
            claims: new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, request.UserName)
            },
            signingCredentials: new SigningCredentials(
                _jwtSettings.SymmetricSecurityKey,
                SecurityAlgorithms.HmacSha256));

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new JwtResponse
        {
            AccessToken = accessToken
        };
    }
}
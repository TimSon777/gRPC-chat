using Auth;
using Microsoft.AspNetCore.Authorization;
using Server.Abstractions;
using Server.Mappers;

namespace Server.Services;

public sealed class AuthService : Auth.Auth.AuthBase
{
    private readonly IJwtProvider _jwtProvider;

    public AuthService(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    [AllowAnonymous]
    public Task<LoginResponse> Login(LoginRequest request)
    {
        var jwtRequest = request.Map();
        var jwtResponse = _jwtProvider.Generate(jwtRequest);
        var loginResponse = jwtResponse.Map();

        return Task.FromResult(loginResponse);
    }
}
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Proto;
using Server.Abstractions;
using Server.Mappers;

namespace Server.Services;

public sealed class AuthService : Auth.AuthBase
{
    private readonly IJwtProvider _jwtProvider;

    public AuthService(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }
    
    [AllowAnonymous]
    public override Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
    {
        var jwtRequest = request.Map();
        var jwtResponse = _jwtProvider.Generate(jwtRequest);
        var loginResponse = jwtResponse.Map();
    
        return Task.FromResult(loginResponse);
    }
}
using Server.Models;

namespace Server.Abstractions;

public interface IJwtProvider
{
    JwtResponse Generate(JwtRequest request);
}
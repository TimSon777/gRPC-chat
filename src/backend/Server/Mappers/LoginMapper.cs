using Proto;
using Server.Models;

namespace Server.Mappers;

public static class LoginMapper
{
    public static JwtRequest Map(this LoginRequest request) => new()
    {
        UserName = request.UserName
    };

    public static LoginResponse Map(this JwtResponse response) => new()
    {
        AccessToken = response.AccessToken
    };
}
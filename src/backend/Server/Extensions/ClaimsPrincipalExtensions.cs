// ReSharper disable once CheckNamespace
namespace System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static string UserName(this ClaimsPrincipal principal)
    {
        return principal.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
}
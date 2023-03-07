using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.IdentityModel.Tokens;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Configuration;

public sealed class JwtSettings
{
    public const string SectionKey = "JWT_SETTINGS";

    [Required]
    [ConfigurationKeyName("KEY")]
    public string Key { get; set; } = default!;

    [Required]
    [ConfigurationKeyName("ISSUER")]
    public string Issuer { get; set; } = default!;

    [Required]
    [ConfigurationKeyName("AUDIENCE")]
    public string Audience { get; set; } = default!;

    public SymmetricSecurityKey SymmetricSecurityKey => new(Encoding.Default.GetBytes(Key));
}
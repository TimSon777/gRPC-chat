using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Configuration;

public sealed class JwtSettings
{
    public const string SectionKey = "JWT_SETTINGS";

    [Required]
    [ConfigurationKeyName("KEY")]
    public string Key { get; set; }

    [Required]
    [ConfigurationKeyName("ISSUER")]
    public string Issuer { get; set; }

    [Required]
    [ConfigurationKeyName("AUDIENCE")]
    public string Audience { get; set; }
}
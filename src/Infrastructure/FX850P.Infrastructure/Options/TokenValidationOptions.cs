using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace FX850P.Infrastructure.Options;

public class TokenValidationOptions
{
    public bool ValidateIssuer => !string.IsNullOrWhiteSpace(ValidIssuer);
    public string ValidIssuer { get; set; } = default!;

    public bool ValidateAudience => !string.IsNullOrWhiteSpace(ValidAudience);
    public string ValidAudience { get; set; } = default!;

    public bool RequireHttpsMetadata { get; set; }

    public string Key { get; set; } = "mysupersecret_secretkey!123";
    public SymmetricSecurityKey IssuerSigningKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

    public bool ValidateLifetime { get; set; }

    public int LifeTimeInMinutes { get; set; }

    public TimeSpan LifeTime => TimeSpan.FromMinutes(LifeTimeInMinutes);

    public int ClockSkewInMinutes { get; set; }
    public TimeSpan ClockSkew => TimeSpan.FromMinutes(ClockSkewInMinutes);
}

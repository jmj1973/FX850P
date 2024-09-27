using FX850P.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FX850P.Presistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
             new ApplicationUser
             {
                 Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                 Email = "administrator@jmj1973.co.za",
                 NormalizedEmail = "ADMINISTRATOR@JMJ1973.CO.ZA",
                 FirstName = "System",
                 LastName = "Admin",
                 UserName = "administrator@jmj1973.co.za",
                 NormalizedUserName = "ADMINISTRATOR@JMJ1973.CO.ZA",
                 PasswordHash = hasher.HashPassword(null, "123Pa$$word!"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                 Email = "user@jmj1973.co.za",
                 NormalizedEmail = "USER@JMJ1973.CO.ZA",
                 FirstName = "System",
                 LastName = "User",
                 UserName = "user@jmj1973.co.za",
                 NormalizedUserName = "USER@JMJ1973.CO.ZA",
                 PasswordHash = hasher.HashPassword(null, "!Password01"),
                 EmailConfirmed = true
             }
        );
    }
}

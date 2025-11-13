using FX850P.Domain.Entities;
using FX850P.Domain.Entities.Identity;
using FX850P.Presistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FX850P.Presistence;

public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Test> Tests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Add Confiurations
        builder.ApplyConfigurationsFromAssembly(typeof(RoleConfiguration).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>

        base.SaveChangesAsync(cancellationToken);

}

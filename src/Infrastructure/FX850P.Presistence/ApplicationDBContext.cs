using System.Threading;
using System.Threading.Tasks;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Add Confiurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleConfiguration).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        //foreach (var entry in ChangeTracker.Entries<BaseAuditDomainEnity<int>>())
        //{
        //    entry.Entity.DateModified = DateTime.Now.ToUniversalTime();

        //    if (entry.State == EntityState.Added)
        //    {
        //        entry.Entity.DateCreated = DateTime.Now.ToUniversalTime();
        //    }
        //}

        base.SaveChangesAsync(cancellationToken);

}

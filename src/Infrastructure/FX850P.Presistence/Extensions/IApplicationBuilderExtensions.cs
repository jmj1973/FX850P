using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FX850P.Presistence.Extensions;

public static class IApplicationBuilderExtensions
{
    public static void MigrateDbContext<TDbContext>(this IApplicationBuilder app) where TDbContext : DbContext
    {
        TDbContext dbContext = default!;

        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            dbContext = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();
            dbContext.Database.Migrate();
        }

        return;
    }
}

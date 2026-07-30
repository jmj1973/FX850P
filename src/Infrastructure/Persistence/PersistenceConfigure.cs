using Microsoft.AspNetCore.Builder;
using Persistence.Extensions;

namespace Persistence;

public static class PersistenceConfigure
{
    public static IApplicationBuilder UsePresistence(this IApplicationBuilder app)
    {
        app.MigrateDbContext<ApplicationDBContext>();

        return app;
    }
}

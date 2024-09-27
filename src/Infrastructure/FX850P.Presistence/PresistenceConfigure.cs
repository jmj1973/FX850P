using FX850P.Presistence.Extensions;
using Microsoft.AspNetCore.Builder;

namespace FX850P.Presistence;

public static class PresistenceConfigure
{
    public static IApplicationBuilder UsePresistence(this IApplicationBuilder app)
    {
        app.MigrateDbContext<ApplicationDBContext>();

        return app;
    }
}

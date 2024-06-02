using Microsoft.AspNetCore.Builder;
using FX850P.Presistence.Extensions;

namespace FX850P.Presistence
{
    public static class PresistenceConfigure
    {
        public static IApplicationBuilder UsePresistence(this IApplicationBuilder app)
        {
            app.MigrateDbContext<ApplicationDBContext>();

            return app;
        }
    }
}

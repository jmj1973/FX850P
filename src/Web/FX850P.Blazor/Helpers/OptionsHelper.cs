using FX850P.Infrastructure.Options;
using FX850P.Blazor.Options;

namespace FX850P.Blazor.Helpers
{
    public class OptionsHelper
    {
        internal static void Configure(AppOptions options)
        {
            options.Inject(new BioServiceBlazorAppOptions());
        }
    }
}

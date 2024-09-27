using FX850P.Blazor.Options;
using FX850P.Infrastructure.Options;

namespace FX850P.Blazor.Helpers;

public static class OptionsHelper
{
    internal static void Configure(AppOptions options) => options.Inject(new BioServiceBlazorAppOptions());
}

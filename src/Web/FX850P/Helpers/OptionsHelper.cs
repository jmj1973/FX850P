using FX850P.Options;
using Infrastructure.Options;

namespace FX850P.Helpers;

public static class OptionsHelper
{
    internal static void Configure(AppOptions options) => options.Inject(new Fx850pBlazorAppOptions());
}

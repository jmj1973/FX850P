using Microsoft.Extensions.Configuration;

namespace FX850P.Infrastructure.Extensions;

public static class IConfigurationExtensions
{
    public static T Get<T, TDefault>(this IConfiguration configuration) where TDefault : T, new()
    {
        var result = new TDefault();
        configuration.Bind(result);
        return result;
    }
}

using Microsoft.Extensions.Configuration;

namespace FX850P.Infrastructure.Extensions
{
    public static class IConfigurationExtensions
    {
        public static T Get<T, DefaultT>(this IConfiguration configuration) where DefaultT : T, new()
        {
            var result = new DefaultT();
            configuration.Bind(result);
            return result;
        }
    }
}

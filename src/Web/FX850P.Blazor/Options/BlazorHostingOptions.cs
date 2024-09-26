using FX850P.Infrastructure.Options;

namespace FX850P.Blazor.Options;

public class BlazorHostingOptions : HostingOptions
{
    public BlazorHostingOptions()
    {
        Port = 40000;
        SslPort = 40001;
        ServiceName = "FX850P";
        Redirect = false;
    }
}

using Infrastructure.Options;

namespace FX850P.Options;

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

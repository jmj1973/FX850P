
using System.Collections.Generic;

namespace FX850P.Infrastructure.Options;

public class HostingOptions
{
    //Define Hosting Options
    // To disable a scheme set port to 0.
    // Json Example (Disable Http)
    // "HostingOptions": {
    //    "Port" : 0,    
    // },
    public int Port { get; set; } = 5000;
    public int? SslPort { get; set; } = default!;
    public string SSLCertificateName { get; set; } = "jmj1973.pfx";
    public string SSLCertificatePassword { get; set; } = "foxhound";
    public string ServiceName { get; set; } = "HostingOptions";

    private bool? _redirect;
    public bool Redirect
    {
        get
        {
            if (_redirect == null)
            {
                if (SslPort == null || SslPort == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return _redirect.Value;
            }
        }
        set
        {
            _redirect = value;
        }
    }

    public string[] Urls
    {
        get
        {
            var result = new List<string>();

            if (Port != 0)
                result.Add($"http://*:{Port}");
            if (UseSSL)
                result.Add($"https://*:{SslPort}");

            return result.ToArray();
        }
    }

    public bool UseSSL { get { return ((SslPort ?? 0) != 0); } }

    public void Inject(HostingOptions other)
    {
        Port = other.Port;
        SslPort = other.SslPort;
        SSLCertificateName = other.SSLCertificateName;
        SSLCertificatePassword = other.SSLCertificatePassword;
    }

    public int GetPreferedPort()
    {
        int sslPort = (SslPort ?? Port);

        return UseSSL ? sslPort : Port;
    }

}

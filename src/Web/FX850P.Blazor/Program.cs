using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using FX850P.Blazor.Options;
using FX850P.Infrastructure.Extensions;
using FX850P.Infrastructure.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace FX850P.Blazor;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            // How do we return the problem?  Console?
            Console.Error.WriteLine($"Critical Error: Exception of type {ex.GetType().Name}, with message '{ex.ToString()}'");
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        HostingOptions hostingOptions = GetHostingOptions(args);

        return Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration(conf => conf.SetBasePath(AppDomain.CurrentDomain.BaseDirectory))
                    .UseWindowsService(options => options.ServiceName = hostingOptions.ServiceName)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseKestrel(cfg => ConfigureKestrel(cfg, hostingOptions));
                        webBuilder.UseContentRoot(GetContentRoot());
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(hostingOptions.Urls);
                    });
    }

    private static void ConfigureKestrel(KestrelServerOptions options, HostingOptions hostingOptions)
    {
        // Add certificate if SSL is enabled
        if (hostingOptions.UseSSL)
        {
            string? certificateLocation = Path.Combine(GetContentRoot(), hostingOptions.SSLCertificateName);

            options.ConfigureHttpsDefaults(listenOptions =>
            {
                // certificate is an X509Certificate2
                listenOptions.ServerCertificate = new X509Certificate2(certificateLocation, hostingOptions.SSLCertificatePassword);
                listenOptions.AllowAnyClientCertificate();
            });

            if (hostingOptions.SslPort.HasValue)
            {
                options.Listen(IPAddress.Any, hostingOptions.SslPort.Value, listenOptions => listenOptions.UseHttps());
            }
        }

        if (hostingOptions.Port != 0)
        {
            options.Listen(IPAddress.Any, hostingOptions.Port);
        }

        //BadHttpRequestException due to MinRequestBodyDataRate and poor connection
        options.Limits.MinRequestBodyDataRate = new MinDataRate(bytesPerSecond: 80, gracePeriod: TimeSpan.FromSeconds(20));
        options.Limits.MinResponseDataRate = new MinDataRate(bytesPerSecond: 80, gracePeriod: TimeSpan.FromSeconds(20));
    }

    private static HostingOptions GetHostingOptions(string[] args)
    {
        // Extract options from appsettings.json,enviromentvariables and commandline arg
        IConfigurationRoot config = new ConfigurationBuilder()
                                           .SetBasePath(GetContentRoot())
                                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                           .AddEnvironmentVariables()
                                           .AddCommandLine(args)
                                           .Build();

        // Get Hosting options from configuration merged with application defaults. Configuration takes presendence.              
        return config.GetSection("HostingOptions").Get<HostingOptions, BlazorHostingOptions>();
    }

    private static string GetContentRoot() => AppDomain.CurrentDomain.BaseDirectory;

}

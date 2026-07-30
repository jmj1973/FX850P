using FX850P.Components.Account;
using FX850P.Contracts;
using FX850P.Helpers;
using FX850P.Options;
using FX850P.Services;
using Domain.Entities.Identity;
using Infrastructure.Extensions;
using Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FX850P.Extensions;

public static class BlazorServiceExtensions
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var appOptions = new Fx850pBlazorAppOptions();

        TokenValidationOptions? tokenValidationOptions = configuration.GetSection("TokenValidationOptions")
                                                                      .Get<TokenValidationOptions>();
        ArgumentNullException.ThrowIfNull(tokenValidationOptions);

        HostingOptions hostingOptions = configuration.GetSection("HostingOptions")
                                          .Get<HostingOptions, BlazorHostingOptions>();

        string cookieName = $"{appOptions.ProductName}.{hostingOptions.Port}";

        // Authentication: Enable JwtBearer and Cookie Authentication
        services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddCookie(options =>
                {
                    options.Cookie.Name = cookieName;
                    options.SlidingExpiration = true;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = tokenValidationOptions.RequireHttpsMetadata;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = tokenValidationOptions.ValidateIssuer,
                        ValidIssuer = tokenValidationOptions.ValidIssuer,
                        ValidateAudience = tokenValidationOptions.ValidateAudience,
                        ValidAudience = tokenValidationOptions.ValidAudience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = tokenValidationOptions.IssuerSigningKey,
                        ValidateLifetime = tokenValidationOptions.ValidateLifetime,
                        ClockSkew = tokenValidationOptions.ClockSkew,
                    };
                });



        return services;
    }


    public static IServiceCollection ConfigureBlazorServices(this IServiceCollection services)
    {
        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        // Lookup services
        services.AddTransient<IRoleLookupService, RoleLookupService>();

        return services;
    }


    public static IServiceCollection AddBlazorOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppOptions>(options => OptionsHelper.Configure(options));
        services.Configure<TokenValidationOptions>(configuration.GetSection("TokenValidationOptions"));

        HostingOptions hostingOptions = configuration.GetSection("HostingOptions").Get<HostingOptions, BlazorHostingOptions>();
        services.Configure<HostingOptions>(options => options.Inject(hostingOptions));

        return services;
    }
}

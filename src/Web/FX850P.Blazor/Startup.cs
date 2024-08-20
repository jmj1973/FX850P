using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using FX850P.Application;
using FX850P.Blazor.Components.Account;
using FX850P.Domain.Entities.Identity;
using FX850P.Blazor.Extensions;
using FX850P.Infrastructure;
using FX850P.Presistence;
using System.Reflection;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using Serilog;

namespace FX850P.Blazor
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _hostingEnvironment;

        private const string DefaultCorsPolicyName = "AllowAll";

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();

            _hostingEnvironment = env;

            // Make available via static properties when DI not available (not really elegant)
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // changing to 3.1
            //https://stackoverflow.com/questions/53840298/how-to-fix-obsolete-iloggerfactory-methods
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                if (_hostingEnvironment.IsDevelopment())
                {
                    loggingBuilder.AddConsole();
                }
                loggingBuilder.AddDebug();

                var logger = new LoggerConfiguration()
                                    .ReadFrom.Configuration(Configuration)
                                    .Enrich.FromLogContext()
                                    .CreateLogger();
                loggingBuilder.AddSerilog(logger);
            });

            services.AddBlazorOptions(Configuration);

            services.AddRazorComponents()
                    .AddInteractiveServerComponents();

            services.AddMudServices();

            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityUserAccessor>();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationDBContext>()
                    .AddSignInManager()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationServices(Configuration);
            services.ConfigureInfrastructureServices(Configuration);
            services.ConfigurePresistenceServices(Configuration);

            // Add Authentication: Cookies and JwtBearer
            services.AddAuthentication(Configuration);

            services.AddCors(o =>
            {
                o.AddPolicy(DefaultCorsPolicyName, builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.ConfigureBlazorServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //The ASP.NET Core security headers guide
            //https://blog.elmah.io/the-asp-net-core-security-headers-guide/
            app.Use(async (context, next) =>
            {
                //Hackers iframe your website to trick users into clicking unintended links. The X-Frame-Options tell any client that framing isn't allowed. 
                //The header can be easily added using middleware:
                //Change the value to SAMEORIGIN to allow your site to iframe pages.
                context.Response.Headers.Append("X-Frame-Options", "DENY");
                //The X-Xss-Protection header will cause most modern browsers to stop loading the page when a cross-site scripting attack is identified. 
                //The header can be added through middleware:
                context.Response.Headers.Append("X-Xss-Protection", "1; mode=block");
                //MIME-type sniffing is an attack where a hacker tries to exploit missing metadata on served files. 
                //The header can be added in middleware:
                context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
                //When you click a link on a website, the calling URL is automatically transferred to the linked site. Unless this is necessary, 
                //you should disable it using the Referrer-Policy header:
                context.Response.Headers.Append("Referrer-Policy", "no-referrer");
                //You are probably not using Flash. Right? Right!!? If not, you can disable the possibility of F
                //lash making cross-site requests using the X-Permitted-Cross-Domain-Policies header:
                context.Response.Headers.Append("X-Permitted-Cross-Domain-Policies", "none");

                await next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //https://blog.elmah.io/the-asp-net-core-security-headers-guide/
                //https://neelbhatt.com/2018/02/04/enforce-ssl-and-use-hsts-in-net-core-net-core-security-part-i/
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(DefaultCorsPolicyName);

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorComponents<Components.App>()
                         .AddInteractiveServerRenderMode();

                endpoints.MapAdditionalIdentityEndpoints();

                //Disabling the Register
                endpoints.MapGet("/Identity/Account/Register", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapPost("/Identity/Account/Register", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapGet("/Identity/Account/ConfirmEmail", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapPost("/Identity/Account/ConfirmEmail", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapGet("/Identity/Account/ForgotPassword", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapPost("/Identity/Account/ForgotPassword", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapGet("/Identity/Account/ResetPassword", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapPost("/Identity/Account/ResetPassword", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapGet("/Identity/Account/SendCode", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapPost("/Identity/Account/SendCode", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapGet("/Identity/Account/VerifyCode", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
                endpoints.MapPost("/Identity/Account/VerifyCode", context => Task.Run(() => context.Response.Redirect("/Identity/Account/Login", true, true)));
            });

            app.UsePresistence();
        }
    }
}

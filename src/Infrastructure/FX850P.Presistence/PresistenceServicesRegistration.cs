using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using FX850P.Application.Identity.Interfaces;
using FX850P.Application.Identity.Models;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Presistence.Repositories;
using FX850P.Presistence.Services;

namespace FX850P.Presistence
{
    public static class PresistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePresistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            var dbType = configuration["dbBackend"];
            var conStr = "";

            //https://www.reddit.com/r/Blazor/comments/ep3mwp/blazor_concurrency_problem_using_entity_framework/
            services.AddDbContextFactory<ApplicationDBContext>(options => 
            {
                if (!string.IsNullOrEmpty(dbType))
                {
                    switch (dbType.ToLower())
                    {
                        case "sqlite":
                            options.UseSqlite(configuration.GetConnectionString("SQLiteConnection"), options =>
                            {
                                options.MigrationsAssembly("FX850P.Presistence.SQLite");
                            });
                            break;
                        case "sqlite.secure":
                            conStr = configuration.GetConnectionString("SQLiteConnection");
                            if (!string.IsNullOrWhiteSpace(conStr) && !conStr.ToLower().Contains("password"))
                            {
                                conStr += ";Password=!h0AaOJ3HNuSy4UEd#";
                            }
                            options.UseSqlite(conStr, options =>
                            {
                                options.MigrationsAssembly("FX850P.Presistence.SQLite");
                            });
                            break;
                        case "postgresql":
                            options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"), options =>
                            {
                                options.MigrationsAssembly("FX850P.Presistence.PostgreSQL");
                            });
                            break;
                        case "mssql":
                        default:
                            //Must have this also "TrustServerCertificate=True"
                            conStr = configuration.GetConnectionString("DefaultConnection");
                            if (!string.IsNullOrWhiteSpace(conStr) && !conStr.ToUpper().Contains("TRUSTSERVERCERTIFICATE"))
                            {
                                conStr += ";TrustServerCertificate=True;";
                            }

                            options.UseSqlServer(conStr, options =>
                            {
                                options.MigrationsAssembly("FX850P.Presistence.MSSQL");
                                options.EnableRetryOnFailure(
                                    maxRetryCount: 5,
                                    maxRetryDelay: TimeSpan.FromSeconds(30),
                                    errorNumbersToAdd: new List<int> { 19, 40, 4060 });
                                //https://devblogs.microsoft.com/dotnet/announcing-ef8-preview-4/
                                //https://learn.microsoft.com/en-gb/sql/t-sql/statements/alter-database-transact-sql-compatibility-level?view=sql-server-ver16#compatibility_level--160--150--140--130--120--110--100--90--80-
                                //SQL Server 2014 (12.x)	12	120
                                options.UseCompatibilityLevel(120);
                            });
                            break;
                    }
                }
                else
                {
                    //Must have this also "TrustServerCertificate=True"
                    conStr = configuration.GetConnectionString("DefaultConnection");
                    if (!string.IsNullOrWhiteSpace(conStr) && !conStr.ToUpper().Contains("TRUSTSERVERCERTIFICATE"))
                    {
                        conStr += ";TrustServerCertificate=True;";
                    }

                    options.UseSqlServer(conStr, options =>
                    {
                        options.MigrationsAssembly("FX850P.Presistence.MSSQL");
                        options.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: new List<int> { 19, 40, 4060 });
                        //https://devblogs.microsoft.com/dotnet/announcing-ef8-preview-4/
                        //https://learn.microsoft.com/en-gb/sql/t-sql/statements/alter-database-transact-sql-compatibility-level?view=sql-server-ver16#compatibility_level--160--150--140--130--120--110--100--90--80-
                        //SQL Server 2014 (12.x)	12	120
                        options.UseCompatibilityLevel(120);
                    });
                }

                options.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
                options.EnableSensitiveDataLogging();
            });

            /* Move to API of UI
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<ApplicationDBContext>()
                    //.AddDefaultUI()
                    .AddDefaultTokenProviders();
            */

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<IBankingDetailRepository, BankingDetailRepository>();
            //services.AddScoped<ICompanyRepository, CompanyRepository>();
            //services.AddScoped<IChargeTypeRepository, ChargeTypeRepository>();
            //services.AddScoped<IDamageProductRepository, DamageProductRepository>();
            //services.AddScoped<IDamageReportTypeRepository, DamageReportTypeRepository>();
            //services.AddScoped<IDamageReportRepository, DamageReportRepository>();
            //services.AddScoped<IDocumentRepository, DocumentRepository>();
            //services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            //services.AddScoped<IJobHistoryRepository, JobHistoryRepository>();
            //services.AddScoped<IJobRepository, JobRepository>();
            //services.AddScoped<ILabourCodeRepository, LabourCodeRepository>();
            //services.AddScoped<ILineItemRepository, LineItemRepository>();
            //services.AddScoped<IPartHistoryRepository, PartHistoryRepository>();
            //services.AddScoped<IPartRepository, PartRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IStatusStateRepository, StatusStateRepository>();
            //services.AddScoped<IStatusFlagRepository, StatusFlagRepository>();
            //services.AddScoped<ITechnicianRepository, TechnicianRepository>();
            //services.AddScoped<INoteGeneralRepository, NoteGeneralRepository>();
            //services.AddScoped<INoteTechnicalRepository, NoteTechnicalRepository>();
            //services.AddScoped<IAuditLogRepository, AuditLogRepository>();

            /* Move to API of UI
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });
            */

            return services;
        }
    }
}

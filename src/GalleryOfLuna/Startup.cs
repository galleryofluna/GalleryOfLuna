using FluentValidation;

using GalleryOfLuna.Configuration;
using GalleryOfLuna.Derpibooru.EntityFramework;
using GalleryOfLuna.EntityFramework;
using GalleryOfLuna.EntityFramework.PostgreSQL;
using GalleryOfLuna.EntityFramework.Sqlite;
using GalleryOfLuna.Extensions;
using GalleryOfLuna.Jobs;
using GalleryOfLuna.Vk;

using Serilog;

using System.Text;

using IL.FluentValidation.Extensions.Options;

using Microsoft.Extensions.Options;

namespace GalleryOfLuna
{
    internal class Startup
    {
        private static Serilog.ILogger _logger = Log.ForContext<Startup>();

        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IValidator<TargetsConfiguration>, TargetsConfiguration.Validator>();

            services.AddOptions<DatabaseConfiguration>(Sections.Database)
                .BindConfiguration(Sections.Database)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddOptions<DatabaseConfiguration>(Sections.Derpibooru)
                .BindConfiguration(Sections.Derpibooru)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddOptions<VkConfiguration>()
                .BindConfiguration(Sections.Vk)
                .ValidateOnStart();
            services.AddTransient<VkConfiguration>(_ => _.GetRequiredService<IOptions<VkConfiguration>>().Value);

            services.AddOptions<TargetsConfiguration>()
                .BindConfiguration(Sections.Targets)
                .ValidateWithFluentValidator()
                .ValidateOnStart();

            var dbConfiguration = Configuration.GetRequiredSection(Sections.Database).Get<DatabaseConfiguration>()!;

            switch (dbConfiguration.Type)
            {
                case DatabaseTypes.PostgreSQL:
                    services.AddDbContextPool<PublishingDbContext, PostgreSqlPublishingDbContext>(
                        dbConfiguration.ConnectionString,
                        DatabaseTypes.PostgreSQL,
                        dbConfiguration.MaximumConnections);
                    break;

                case DatabaseTypes.Default:
                case DatabaseTypes.SQLite:
                    services.AddDbContextPool<PublishingDbContext, SqlitePublishingDbContext>(
                        dbConfiguration.ConnectionString,
                        DatabaseTypes.SQLite,
                        dbConfiguration.MaximumConnections);
                    break;

                default:
                    throw new NotSupportedException("Provided RDBMS type is not supported");
            }

            dbConfiguration = Configuration.GetSection(Sections.Derpibooru).Get<DatabaseConfiguration>();
            services.AddDbContextPool<DerpibooruDbContext, DerpibooruDbContext>(
                dbConfiguration!.ConnectionString,
                DatabaseTypes.PostgreSQL,
                dbConfiguration.MaximumConnections);

            services.AddHealthChecks()
                .AddDbContextCheck<DerpibooruDbContext>()
                .AddDbContextCheck<PublishingDbContext>();

            services.AddMemoryCache();
            services.AddHttpClient();
            services.AddScoped<VkClient>();

            // Required for 'windows-1251' responses from VK API
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddHostedService<Scheduler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}

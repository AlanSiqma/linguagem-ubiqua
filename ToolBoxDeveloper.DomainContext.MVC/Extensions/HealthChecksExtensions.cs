using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToolBoxDeveloper.DomainContext.Domain.Settings;
using ToolBoxDeveloper.DomainContext.MVC.CustomHealthChecks;

namespace ToolBoxDeveloper.DomainContext.MVC.Extensions
{
    public static class HealthChecksExtensions
    {
        public  static void UseHealthChecksConfiguration(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = p => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });
        }
        public static void AddHealthChecksConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            var configurationSection = Configuration.GetSection(nameof(DatabaseSettings));
            DatabaseSettings appSettings = new DatabaseSettings();
            ConfigurationBinder.Bind(configurationSection, appSettings);

            services.AddHealthChecks()
                .AddMongoDb(mongodbConnectionString: appSettings.ConnectionString,
                name: "Instancia mongoDB");
                //.AddCheck<DependeciesValidadeHealthCheck>("Health Checks customizavel");

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.SetEvaluationTimeInSeconds(5);
                setup.MaximumHistoryEntriesPerEndpoint(10);
                setup.AddHealthCheckEndpoint("API com Health Checks", "/health");
            }).AddInMemoryStorage(); 

            services.AddHealthChecksUI();
        }
    }
}

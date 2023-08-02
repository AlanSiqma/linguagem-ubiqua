using Devtoolkit.LinguagemUbiqua.Domain.Settings;
using Devtoolkit.LinguagemUbiqua.MVC.CustomHealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Devtoolkit.LinguagemUbiqua.MVC.Extensions
{
    public static class HealthChecksExtensions
    {
        public static void UseHealthChecksConfiguration(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/dashboard";

            });
        }
        public static void AddHealthChecksConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

            var serviceProvider = services.BuildServiceProvider();
            var appSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;

            services.AddHealthChecks()
                .AddMongoDb(appSettings.ConnectionString, name: "Instancia mongoDB")
                .AddCheck<DependeciesValidadeHealthCheck>("Health Checks customizavel");

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.SetEvaluationTimeInSeconds(5);
                setup.MaximumHistoryEntriesPerEndpoint(10);
                setup.AddHealthCheckEndpoint("API com Health Checks", "/health");
            }).AddInMemoryStorage();
        }
    }
}

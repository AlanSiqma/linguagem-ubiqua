using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services;
using ToolBoxDeveloper.DomainContext.Domain.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Settings;
using ToolBoxDeveloper.DomainContext.Infra.Data;
using ToolBoxDeveloper.DomainContext.Services;

namespace ToolBoxDeveloper.DomainContext.IoC
{
    public static class InjectionConfiguration
    {
        public static IServiceCollection AddInjectionConfiguration(this IServiceCollection service)
        {
            service.AddSingleton<INotifier, Notifier>();
            service.AddTransient<IDomainContextService, DomainContextService>();
            service.AddTransient<IDomainContextRepository, DomainContextRepository>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IUserRepository, UserRepository>();

            return service;
        }
        public static IServiceCollection AddInjectionConfigurationDataBase(this IServiceCollection service, IConfiguration configuration)
        {
            var configurationSection = configuration.GetSection(nameof(DatabaseSettings));
            DatabaseSettings appSettings = new();
            ConfigurationBinder.Bind(configurationSection, appSettings);

            var client = new MongoClient(appSettings.ConnectionString);
            var database = client.GetDatabase(appSettings.DatabaseName);

            service.AddSingleton(database);                        

            return service;
        }
    }
}

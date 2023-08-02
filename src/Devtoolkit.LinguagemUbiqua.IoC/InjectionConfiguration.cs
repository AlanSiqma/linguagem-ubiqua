using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Notifications;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Services;
using Devtoolkit.LinguagemUbiqua.Domain.Notifications;
using Devtoolkit.LinguagemUbiqua.Domain.Settings;
using Devtoolkit.LinguagemUbiqua.Infra.Data;
using Devtoolkit.LinguagemUbiqua.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Devtoolkit.LinguagemUbiqua.IoC
{
    public static class InjectionConfiguration
    {
        public static IServiceCollection AddInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IDomainContextService, DomainContextService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDomainContextRepository, DomainContextRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddInjectionConfigurationDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = new DatabaseSettings();
            configuration.GetSection(nameof(DatabaseSettings)).Bind(databaseSettings);
            services.AddSingleton(databaseSettings);

            services.AddSingleton<IMongoClient>(provider =>
            {
                var settings = provider.GetRequiredService<DatabaseSettings>();
                return new MongoClient(settings.ConnectionString);
            });

            services.AddScoped<IMongoDatabase>(provider =>
            {
                var client = provider.GetRequiredService<IMongoClient>();
                var settings = provider.GetRequiredService<DatabaseSettings>();
                return client.GetDatabase(settings.DatabaseName);
            });

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using ToolBoxDeveloper.DomainContext.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.Infra.Data;
using ToolBoxDeveloper.DomainContext.Services;

namespace ToolBoxDeveloper.DomainContext.IoC
{
    public static class InjectionConfiguration
    {
        public static IServiceCollection AddInjectionConfiguration(this IServiceCollection service)
        {
            service.AddTransient<IDomainContextService, DomainContextService>();
            service.AddTransient<IDomainContextRepository, DomainContextRepository>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IUserRepository, UserRepository>();

            return service;
        }
    }
}

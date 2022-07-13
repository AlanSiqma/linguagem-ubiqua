using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ToolBoxDeveloper.DomainContext.MVC.CustomHealthChecks
{
    public class DependeciesValidadeHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            var hCheck = new HealthCheckResult
                        (status: HealthStatus.Unhealthy,description: "API está doente");

            return Task.FromResult(hCheck);
        }
    }
}

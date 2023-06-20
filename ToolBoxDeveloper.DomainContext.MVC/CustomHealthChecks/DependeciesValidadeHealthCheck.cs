using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace ToolBoxDeveloper.DomainContext.MVC.CustomHealthChecks
{
    public class DependeciesValidadeHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var hCheck = new HealthCheckResult
                        (status: HealthStatus.Healthy, description: "API não está doente");

            return Task.FromResult(hCheck);
        }
    }
}

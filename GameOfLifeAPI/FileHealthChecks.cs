using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GameOfLifeAPI {
    public class FileHealthChecks : IHealthCheck {
        private readonly IConfiguration _configuration;

        public FileHealthChecks(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var path = _configuration["FilePath"];
            if (File.Exists(path)) {
                try {

                    var healthCheckResultHealthy = File.Open(path, FileMode.Open);
                    
                    healthCheckResultHealthy.Close();
                    return Task.FromResult(HealthCheckResult.Healthy("A healthy result!"));
                } catch (Exception e) {
                    return Task.FromResult(HealthCheckResult.Unhealthy("A unhealthy result! (File exist but can´t read"));
                }
            }
            return Task.FromResult(HealthCheckResult.Unhealthy("A unhealthy result! (File does not exist)"));

        }
    }
}

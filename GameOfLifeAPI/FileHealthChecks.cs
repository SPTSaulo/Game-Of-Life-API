using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLifeAPI {
    public class FileHealthChecks : IHealthCheck {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) {
            var path = @"boardLog.txt";
            if (File.Exists(path)) {
                try {
                    var healthCheckResultHealthy = File.Open(path, FileMode.OpenOrCreate);
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

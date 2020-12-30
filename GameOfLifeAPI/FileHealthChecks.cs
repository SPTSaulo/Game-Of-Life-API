using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GameOfLifeAPI {
    public class FileHealthChecks : IHealthCheck {
        private readonly IConfiguration configuration;
        private readonly ILogger _loger;

        public FileHealthChecks(IConfiguration configuration, ILogger<FileHealthChecks> loger) {
            this.configuration = configuration;
            _loger = loger;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) {
            
            try {
                var filePath = Directory.GetCurrentDirectory() + "/dummyLogs.txt";
                File.AppendAllText(filePath, "Escribo"); 
                File.Delete(filePath); 
                return Task.FromResult(HealthCheckResult.Healthy("Healthy result"));
            } catch (Exception e) {
                return Task.FromResult(HealthCheckResult.Unhealthy("A unhealthy result! (File does not have permissions)"));
            }
        }
    }
}

using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.IO;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GameOfLifeAPI {
    public class FileHealthChecks : IHealthCheck {
        private readonly IConfiguration configuration;
        private readonly ILogger _loger;
        private string directoryPath;

        public FileHealthChecks(IConfiguration configuration)
        {
            this.configuration = configuration;
            directoryPath = configuration["DirectoryLogs"];
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (Directory.Exists(directoryPath)) {
                try {
                    var filePath = configuration["DirectoryLogs"] + "\\dummyLogs.txt";
                    File.AppendAllText(filePath, "Escribo");
                    File.Delete(filePath);
                    return Task.FromResult(HealthCheckResult.Healthy("Healthy result"));
                } catch (Exception e) {
                    return Task.FromResult(HealthCheckResult.Unhealthy("A unhealthy result! (File does not have permissions)"));
                }
            }
            return Task.FromResult(HealthCheckResult.Unhealthy($"A unhealthy result! (File does not exist {directoryPath})"));
        }
    }
}

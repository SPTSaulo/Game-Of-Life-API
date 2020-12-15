using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLifeAPI {
    public class FileHealthChecks : IHealthCheck {
        private string directoryPath;

        public FileHealthChecks()
        {
            this.directoryPath = Directory.GetCurrentDirectory();
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (Directory.Exists(directoryPath)) {
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                var atributos = directoryInfo.Attributes;
                
                if((atributos & FileAttributes.ReadOnly) != FileAttributes.ReadOnly) return Task.FromResult(HealthCheckResult.Healthy("A healthy result!"));
                return Task.FromResult(HealthCheckResult.Unhealthy("A unhealthy result! (File exist but can´t write")); 
                
            }
            return Task.FromResult(HealthCheckResult.Unhealthy("A unhealthy result! (File does not exist)"));
        }
    }
}

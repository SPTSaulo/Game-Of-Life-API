using System;
using System.Diagnostics.Eventing.Reader;
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

        public FileHealthChecks(IConfiguration configuration, ILogger<FileHealthChecks> loger)
        {
            this.configuration = configuration;
            directoryPath = configuration["DirectoryLogs"];
            _loger = loger;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            _loger.LogInformation($"El directorio donde se va a escribir el fichero es {directoryPath}");
            _loger.LogInformation($"Existe directorio = {Directory.Exists(directoryPath)}");
            if (Directory.Exists(directoryPath)) {
                try {
                    var filePath = configuration["DirectoryLogs"] + "\\dummyLogs.txt";
                    _loger.LogInformation($"El fichero se va a escribir en {filePath}");
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

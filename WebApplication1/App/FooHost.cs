using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App;

public class FooHost : BackgroundService
{
    private readonly IHostApplicationLifetime _hostLifetime;
    private readonly IHostEnvironment _hostingEnv;
    private readonly IConfiguration _configuration;
    private readonly IFooService _fooService;
    private readonly ILogger<FooHost> _logger;

    public FooHost(
        IHostApplicationLifetime hostLifetime, 
        IHostEnvironment hostingEnv, 
        IConfiguration configuration, 
        ILogger<FooHost> logger,
        IFooService fooService)
    {
        _hostLifetime = hostLifetime;
        _hostingEnv = hostingEnv;
        _configuration = configuration;
        _logger = logger;
        _fooService = fooService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Executing");

        _logger.LogDebug($"Working dir is {_hostingEnv.ContentRootPath}");
        _logger.LogInformation($".NET environment is {_configuration["DOTNET_ENVIRONMENT"]}");
        await _fooService.CopyWrite();
        _logger.LogInformation("Finished executing. Exiting.");
        _hostLifetime.StopApplication();
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting up");
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping");
        return base.StopAsync(cancellationToken);
    }
}
using Microsoft.Extensions.Logging;

namespace App;

public class FooService : IFooService
{
    private readonly ILogger<FooService> _logger;

    public FooService(ILogger<FooService> logger)
    {
        _logger = logger;
    }
    
    public async Task CopyWrite()
    {
        var input = Console.ReadLine();
        _logger.LogInformation("Working");
        await Task.Delay(1000);
        Console.WriteLine(input);
    }
}

public interface IFooService
{
    Task CopyWrite();
}
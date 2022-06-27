namespace TjerenMaskin.App.Services;

public interface IExampleService
{
    Task<string> DoWork(CancellationToken cancellationToken);
}
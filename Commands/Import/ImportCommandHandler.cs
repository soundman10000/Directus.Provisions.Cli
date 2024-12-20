using Microsoft.Extensions.Logging;

namespace Directus.Provisions.Cli;

internal class ImportCommandHandler : ICommandHandler<ImportCommandOptions>
{
    private readonly ILogger<ImportCommandHandler> _logger;

    public ImportCommandHandler(ILogger<ImportCommandHandler> logger)
    {
        this._logger = logger;
    }

    public Task HandleAsync(ImportCommandOptions opts)
    {
        this._logger.LogInformation($"Hello, {opts.Name ?? "World"}!");
        return Task.CompletedTask;
    }
}
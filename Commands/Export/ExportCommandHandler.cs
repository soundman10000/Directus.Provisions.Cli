using Microsoft.Extensions.Logging;

namespace Directus.Provisions.Cli;

internal class ExportCommandHandler : ICommandHandler<ExportCommand>
{
    private readonly ILogger<ExportCommandHandler> _logger;

    public ExportCommandHandler(ILogger<ExportCommandHandler> logger)
    {
        this._logger = logger;
    }

    public Task HandleAsync(ExportCommand opts)
    {
        this._logger.LogInformation($"Sum: {opts.A + opts.B}");

        return Task.CompletedTask;
    }
}
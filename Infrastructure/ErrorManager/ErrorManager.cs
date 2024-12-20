using CommandLine;
using Microsoft.Extensions.Logging;

namespace Directus.Provisions.Cli;

internal class ErrorManager : IErrorManager
{
    private readonly ILogger<ErrorManager> _logger;

    public ErrorManager(ILogger<ErrorManager> logger)
    {
        this._logger = logger;
    }

    public Task LogParseErrors(IEnumerable<Error> errors)
    {
        foreach (var error in errors)
        {
            this._logger.LogError(error.ToString());
        }

        return Task.CompletedTask;
    }

    public Task LogUncaughtExceptions(Exception? exception)
    {
        while (exception != null)
        {
            this._logger.LogError(exception.Message);
            exception = exception.InnerException;
        }

        return Task.CompletedTask;
    }
}
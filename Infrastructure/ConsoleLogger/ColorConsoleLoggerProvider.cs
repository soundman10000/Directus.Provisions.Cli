using Microsoft.Extensions.Logging;

namespace Directus.Provisions.Cli;

public class ColoredConsoleLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string _) => new ColoredConsoleLogger();

    public void Dispose()
    {
    }
}
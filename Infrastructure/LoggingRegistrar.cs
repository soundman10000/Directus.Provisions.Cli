using Microsoft.Extensions.Logging;

namespace Directus.Provisions.Cli;

internal class LoggingRegistrar
{
    public static void SetupLogging(ILoggingBuilder loggingBuilder)
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddProvider(new ColoredConsoleLoggerProvider());
    }
}
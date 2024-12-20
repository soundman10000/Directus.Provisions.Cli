using Microsoft.Extensions.Logging;

namespace Directus.Provisions.Cli
{
    public class ColoredConsoleLogger : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            var color = GetColorForLogLevel(logLevel);

            Console.ForegroundColor = color;
            Console.WriteLine($"[{logLevel}]: {message}");
            Console.ResetColor();
        }

        private static ConsoleColor GetColorForLogLevel(LogLevel logLevel) =>
            logLevel switch
            {
                LogLevel.Trace or LogLevel.Debug => ConsoleColor.Gray,
                LogLevel.Information => ConsoleColor.White,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Critical => ConsoleColor.DarkRed,
                _ => ConsoleColor.White
            };
    }
}

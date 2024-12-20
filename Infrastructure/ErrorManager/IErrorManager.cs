using CommandLine;

namespace Directus.Provisions.Cli;

internal interface IErrorManager
{
    Task LogParseErrors(IEnumerable<Error> errors);

    Task LogUncaughtExceptions(Exception? exception);
}
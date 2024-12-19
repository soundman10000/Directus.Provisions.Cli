namespace Directus.Provisions.Cli;

internal class ExportCommandHandler
{
    public static Task ExecuteAsync(ExportCommand opts)
    {
        Console.WriteLine($"Sum: {opts.A + opts.B}");
        return Task.CompletedTask;
    }
}
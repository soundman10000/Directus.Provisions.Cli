namespace Directus.Provisions.Cli;

internal class ImportCommandHandler
{
    public static Task ExecuteAsync(ImportCommandOptions opts)
    {
        Console.WriteLine($"Hello, {opts.Name ?? "World"}!");
        
        return Task.CompletedTask;
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CommandLine;
using Directus.Provisions.Cli;

public class Program
{
    public static async Task Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(SetupServiceProvider)
            .Build();

        var serviceProvider = host.Services;

        if (args.Length == 0)
        {
            Console.WriteLine("No arguments provided. Usage: dotnet run [command]");
            return;
        }

        await Parser.Default
            .ParseArguments<ExportCommand, ImportCommandOptions>(args)
            .MapResult(
                (ExportCommand opts) => ExportCommandHandler.ExecuteAsync(opts),
                (ImportCommandOptions opts) => ImportCommandHandler.ExecuteAsync(opts),
                errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ToString());
                    }
                    return Task.CompletedTask;
                });
    }

    private static void SetupServiceProvider(IServiceCollection sc)
    {
        // This can be used to add services if needed for your commands
    }
}
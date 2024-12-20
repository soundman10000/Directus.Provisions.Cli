using CommandLine;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static Directus.Provisions.Cli.ServiceProviderRegistrar;
using static Directus.Provisions.Cli.LoggingRegistrar;

namespace Directus.Provisions.Cli;

public class Program
{
    public static async Task Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureLogging(SetupLogging)
            .ConfigureServices(SetupServiceProvider)
            .Build();

        var state = host.Services.GetRequiredService<IState>();

        if (args.Length == 0)
        {
            state.Logger.LogError("No arguments provided. Usage: dotnet run [command]");
            return;
        }

        try
        {
            await Parser.Default
                .ParseArguments<ExportCommand, ImportCommandOptions>(args)
                .MapResult(
                    (ExportCommand opts) => state.HandlerFactory.ExecuteCommand(opts),
                    (ImportCommandOptions opts) => state.HandlerFactory.ExecuteCommand(opts),
                    state.ErrorManager.LogParseErrors);
        }
        catch (Exception e)
        {
            await state.ErrorManager.LogUncaughtExceptions(e);
        }
    }
}
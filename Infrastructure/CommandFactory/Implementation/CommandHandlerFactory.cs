using Microsoft.Extensions.DependencyInjection;

namespace Directus.Provisions.Cli;

internal class CommandHandlerFactory : ICommandHandlerFactory
{
    private readonly IServiceProvider _provider;

    public CommandHandlerFactory(IServiceProvider provider)
    {
        this._provider = provider;
    }

    public Task ExecuteCommand<T>(T opts) =>
        this._provider
            .GetRequiredService<ICommandHandler<T>>()
            .HandleAsync(opts);
}
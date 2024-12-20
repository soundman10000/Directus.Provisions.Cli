using Microsoft.Extensions.Logging;

namespace Directus.Provisions.Cli;

internal interface IState
{
    ICommandHandlerFactory HandlerFactory { get; }
    IErrorManager ErrorManager { get; }
    ILogger Logger { get; }
}

internal class State : IState
{
    public ICommandHandlerFactory HandlerFactory { get; }
    public IErrorManager ErrorManager { get; }
    public ILogger Logger { get; }

    public State(ICommandHandlerFactory handlerFactory, IErrorManager errorManager, ILogger<Program> logger)
    {
        this.HandlerFactory = handlerFactory;
        this.ErrorManager = errorManager;
        this.Logger = logger;
    }
}
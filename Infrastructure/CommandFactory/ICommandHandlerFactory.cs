namespace Directus.Provisions.Cli;

public interface ICommandHandlerFactory
{
    Task ExecuteCommand<T>(T opts);
}
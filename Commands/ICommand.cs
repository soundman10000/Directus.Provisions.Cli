namespace Directus.Provisions.Cli;

public interface ICommandHandler<in T>
{
    public Task HandleAsync(T command);
}
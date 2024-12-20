using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Directus.Provisions.Cli;

public static class ServiceProviderRegistrar
{

    public static void SetupServiceProvider(IServiceCollection sc)
    {
        sc.AddTransient<IState, State>();
        sc.AddTransient<ICommandHandlerFactory, CommandHandlerFactory>();
        sc.AddTransient<IErrorManager, ErrorManager>();
        sc.RegisterCommandHandlers();
    }

    private static IServiceCollection RegisterCommandHandlers(
        this IServiceCollection services)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            if (type is not { IsAbstract: false, IsGenericTypeDefinition: false })
            {
                continue;
            }

            var interfaces = type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));

            foreach (var @interface in interfaces)
            {
                services.AddTransient(@interface, type);
            }
        }

        return services;
    }
}
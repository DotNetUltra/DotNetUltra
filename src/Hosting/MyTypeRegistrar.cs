using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace DotNetUltra.Hosting;

public sealed class DotNetUltraTypeRegistrar(IServiceCollection serviceCollection) : ITypeRegistrar
{
    public ITypeResolver Build()
    {
        return new MyTypeResolver(serviceCollection.BuildServiceProvider());
    }

    public void Register(Type service, Type implementation)
    {
        _ = serviceCollection.AddSingleton(service, implementation);
    }

    public void RegisterInstance(Type service, object implementation)
    {
        _ = serviceCollection.AddSingleton(service, implementation);
    }

    public void RegisterLazy(Type service, Func<object> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        _ = serviceCollection.AddSingleton(service, (provider) => func());
    }
}
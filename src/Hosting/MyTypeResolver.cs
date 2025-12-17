using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Hosting;

public sealed class MyTypeResolver(IServiceProvider provider) : ITypeResolver, IDisposable
{
    private readonly IServiceProvider _provider = provider ?? throw new ArgumentNullException(nameof(provider));

    public object? Resolve(Type? type)
    {
        if (type == null)
        {
            return null;
        }

        return _provider.GetService(type);
    }

    public void Dispose()
    {
        if (_provider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
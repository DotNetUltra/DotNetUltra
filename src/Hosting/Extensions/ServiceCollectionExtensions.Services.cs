using DotNetUltra.Services;
using DotNetUltra.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Hosting.Extensions;

internal static partial class ServiceCollectionExtensions
{
    static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<IGreeterService, GreeterService>()
            .AddSingleton<IBuildCleanService, BuildCleanService>()
            .AddSingleton<IBuildRestoreService, BuildRestoreService>()
            .AddSingleton<IBuildCompileService, BuildCompileService>()
            ;
    }
}

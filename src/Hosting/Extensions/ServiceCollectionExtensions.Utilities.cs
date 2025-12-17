using DotNetUltra.Pipelines;
using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Utilities;
using DotNetUltra.Utilities.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Hosting.Extensions;

internal static partial class ServiceCollectionExtensions
{
    static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        return services
            .AddSingleton<IExternalProcessUtility, ExternalProcessUtility>()
            ;
    }
}

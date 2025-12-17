using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Hosting.Extensions;

internal static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddDotNetUltra(this IServiceCollection services)
    {
        return services
            .AddResolvers()
            .AddUtilities()
            .AddServices()
            .AddPipelines()
            ;
    }
}

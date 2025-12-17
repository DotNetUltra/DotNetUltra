using DotNetUltra.Resolvers;
using DotNetUltra.Resolvers.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Hosting.Extensions;

internal static partial class ServiceCollectionExtensions
{
    static IServiceCollection AddResolvers(this IServiceCollection services)
    {
        return services
            .AddSingleton<IWorkspaceResolver, WorkspaceResolver>()
            ;
    }
}

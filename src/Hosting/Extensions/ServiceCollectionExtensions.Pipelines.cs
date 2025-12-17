using DotNetUltra.Pipelines;
using DotNetUltra.Pipelines.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Hosting.Extensions;

internal static partial class ServiceCollectionExtensions
{
    static IServiceCollection AddPipelines(this IServiceCollection services)
    {
        return services
            .AddSingleton<IBuildCleanPipeline, BuildCleanPipeline>()
            .AddSingleton<IBuildRestorePipeline, BuildRestorePipeline>()
            .AddSingleton<IBuildCompilePipeline, BuildCompilePipeline>()
            .AddSingleton<IBuildFullPipeline, BuildFullPipeline>();
    }
}

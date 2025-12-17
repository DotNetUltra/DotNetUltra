using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Services.Abstractions;

namespace DotNetUltra.Pipelines;

internal class BuildCompilePipeline(IBuildRestoreService buildRestoreService, IBuildCompileService buildBuildService) : IBuildCompilePipeline
{
    public void Execute()
    {
        buildRestoreService.Execute();
        buildBuildService.Execute();
    }
}

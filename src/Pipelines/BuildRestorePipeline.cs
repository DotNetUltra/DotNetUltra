using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Services.Abstractions;

namespace DotNetUltra.Pipelines;

internal class BuildRestorePipeline(IBuildRestoreService buildRestoreService) : IBuildRestorePipeline
{
    public void Execute()
    {
        buildRestoreService.Execute();
    }
}

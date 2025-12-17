using DotNetUltra.Pipelines.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Pipelines;

internal class BuildFullPipeline(IBuildCleanPipeline buildCleanPipeline, IBuildRestorePipeline buildRestorePipeline, IBuildCompilePipeline buildCompilePipeline) : IBuildFullPipeline
{
    public void Execute()
    {
        buildCleanPipeline.Execute();
        buildRestorePipeline.Execute();
        buildCompilePipeline.Execute();
    }
}

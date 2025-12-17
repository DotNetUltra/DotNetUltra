using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Services;
using DotNetUltra.Services.Abstractions;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Pipelines;

internal class BuildCleanPipeline(IBuildCleanService buildCleanService) : IBuildCleanPipeline
{
    public void Execute()
    {
        buildCleanService.Execute();
    }
}

using DotNetUltra.Pipelines.Abstractions;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Commands;

internal sealed class BuildCleanCommand(IBuildCleanPipeline buildCleanPipeline) : Command
{
    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        buildCleanPipeline.Execute();
        return 0;
    }
}
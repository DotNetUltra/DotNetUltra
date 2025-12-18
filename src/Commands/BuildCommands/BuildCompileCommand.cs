using DotNetUltra.Pipelines.Abstractions;
using Spectre.Console.Cli;

namespace DotNetUltra.Commands.BuildCommands;

internal sealed class BuildCompileCommand(IBuildCompilePipeline buildBuildPipeline) : Command
{
    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        buildBuildPipeline.Execute();
        return 0;
    }
}

using DotNetUltra.Pipelines.Abstractions;
using Spectre.Console.Cli;

namespace DotNetUltra.Commands;

internal sealed class BuildRestoreCommand(IBuildRestorePipeline buildRestoreipeline) : Command
{
    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        buildRestoreipeline.Execute();
        return 0;
    }
}

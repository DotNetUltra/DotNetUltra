using Spectre.Console.Cli;

namespace DotNetUltra.Commands.EFCoreCommands;

internal sealed class EFCoreMigrationsRemoveCommand() : Command
{
    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        return 0;
    }
}
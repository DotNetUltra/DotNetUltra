using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Commands;

internal sealed class BuildCommand() : Command
{
    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        return 0;
    }
}
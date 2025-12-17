using DotNetUltra.Services.Abstractions;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DotNetUltra.Commands;

internal sealed class DefaultCommand(IGreeterService greeter) : Command
{
    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        greeter.Execute();
        return 0;
    }
}
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DotNetUltra.Pipelines.Abstractions.Inputs;

internal class EFCoreMigrationAddPipelineInput
{
    public required string Name { get; set; }
    public string? DbContextName { get; set; }
    public string? WorkingProject { get; set; }
    public string? StartupProject { get; set; }
}

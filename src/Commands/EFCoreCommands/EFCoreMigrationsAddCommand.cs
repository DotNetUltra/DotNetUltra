using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Pipelines.Abstractions.Inputs;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static DotNetUltra.Commands.EFCoreCommands.EFCoreMigrationsAddCommand;

namespace DotNetUltra.Commands.EFCoreCommands;

internal sealed class EFCoreMigrationsAddCommand(IEFCoreMigrationAddPipeline _eFCoreMigrationAddPipeline) : Command<Settings>
{
    //dotnet ef migrations add %arg1% -o Data\Migrations\CompanyMigrations -p ..\src\FinancialService\OiSoft.Volta.FinancialService -s ..\src\Applications\OiSoft.Volta.Applications.FinancialService -c VoltaCompanyDbContext

    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[Name]")]
        public required string Name { get; set; }

        [CommandOption("-c|--context <DatabaseContextName>")]
        [Description("The name of the database context when more than one is found")]
        public string? DbContextName { get; set;  }

        [CommandOption("-w|--working-project <WorkingProjectPath>")]
        [Description("Working project where the context resides where more than one is found")]
        public string? WorkingProject { get; set; }

        [CommandOption("-s|--startup-project <StartupProjectPath>")]
        [Description("Startup project used to run the application where more than one is found")]
        public string? StartupProject { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        var pipelineInput = new EFCoreMigrationAddPipelineInput()
        {
            Name = settings.Name,
            DbContextName = settings.DbContextName,
            WorkingProject = settings.WorkingProject,
            StartupProject = settings.StartupProject
        };

        _eFCoreMigrationAddPipeline.Execute(pipelineInput);

        return 0;
    }
}

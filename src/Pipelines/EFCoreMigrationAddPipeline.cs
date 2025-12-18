using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Pipelines.Abstractions.Inputs;
using DotNetUltra.Resolvers.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Pipelines;

internal class EFCoreMigrationAddPipeline(IWorkspaceResolver workspaceResolver) : IEFCoreMigrationAddPipeline
{
    public void Execute(EFCoreMigrationAddPipelineInput input)
    {
        var dbContextName = input.DbContextName ?? FindDatabaseContextName();
        var workingProject = string.Empty;
        var startupProject = string.Empty;


    }

    private string FindDatabaseContextName()
    {
        var relevantFiles = workspaceResolver
            .GetWorkingDirectory().EnumerateFiles(".cs", SearchOption.AllDirectories);


        return string.Empty;
    }


}

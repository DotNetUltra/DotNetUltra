using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Services;
using DotNetUltra.Services.Abstractions;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Pipelines;

internal class BuildCleanPipeline(IWorkspaceService workspaceService) : IBuildCleanPipeline
{
    public void Execute()
    {
        AnsiConsole.WriteLine($" Cleanup Process Started");
        if (workspaceService.IsProjectDirectory())
        {
            CleanProject(workspaceService.GetWorkingDirectory());
        }
        else if (workspaceService.IsSolutionDirectory())
        {
            var projectFiles = workspaceService
                .GetWorkingDirectory()
                .EnumerateFiles("*.csproj", SearchOption.AllDirectories);

            foreach (var projectFile in projectFiles)
            {
                if(projectFile?.Directory == null)
                {
                    continue;
                }

                CleanProject(projectFile.Directory);
            }
        }
    }

    private void CleanProject(DirectoryInfo projectDirectoryInfo)
    {
        var isProjectDirectory = projectDirectoryInfo.EnumerateFiles("*.csproj", SearchOption.TopDirectoryOnly)
            .Any();

        if(isProjectDirectory)
        {

            var binProjectDirectory = projectDirectoryInfo
                .EnumerateDirectories("bin", SearchOption.TopDirectoryOnly)
                .SingleOrDefault();

            var objProjectDirectory = projectDirectoryInfo
                .EnumerateDirectories("obj", SearchOption.TopDirectoryOnly)
                .SingleOrDefault();

            binProjectDirectory?.Delete(true);
            objProjectDirectory?.Delete(true);

            AnsiConsole.WriteLine($" Cleanup finished for project {projectDirectoryInfo.Name}");
        }
        else
        {
            AnsiConsole.WriteLine($" Cleanup skipped for directory {projectDirectoryInfo.Name}");
        }
    }
}

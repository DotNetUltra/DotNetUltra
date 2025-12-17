using DotNetUltra.Resolvers.Abstractions;
using DotNetUltra.Services.Abstractions;
using DotNetUltra.Utilities;
using DotNetUltra.Utilities.Abstractions;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Services;

internal class BuildCleanService(IWorkspaceResolver workspaceService, IExternalProcessUtility externalProcessUtility) : IBuildCleanService
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
                if (projectFile?.Directory == null)
                {
                    continue;
                }

                CleanProject(projectFile.Directory);
            }
        }

        externalProcessUtility.Execute(new ExternalProcessInput()
        {
            Application = ExternalProcessApplication.DotNet,
            Arguments = ["clean"],
            ProcessTimeoutInMilliseconds = -1
        });
    }

    private void CleanProject(DirectoryInfo projectDirectoryInfo)
    {
        var isProjectDirectory = projectDirectoryInfo.EnumerateFiles("*.csproj", SearchOption.TopDirectoryOnly)
            .Any();

        if (isProjectDirectory)
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

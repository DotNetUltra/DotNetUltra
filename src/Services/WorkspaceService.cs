using DotNetUltra.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Services;

internal sealed class WorkspaceService : IWorkspaceService
{
    private readonly string _currentDirectory;

    public WorkspaceService()
    {
        _currentDirectory = Environment.CurrentDirectory;
    }
    public DirectoryInfo GetWorkingDirectory()
    {
        return new DirectoryInfo(_currentDirectory);
    }

    public bool IsProjectDirectory()
    {
        var result = Directory.EnumerateFiles(_currentDirectory, "*.csproj", SearchOption.TopDirectoryOnly)
            .Any();

        return result;
    }

    public bool IsSolutionDirectory()
    {
        var result = Directory.EnumerateFiles(_currentDirectory, "*.sln", SearchOption.TopDirectoryOnly)
            .Any();

        return result;
    }
}

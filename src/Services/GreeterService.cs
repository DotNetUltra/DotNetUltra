using DotNetUltra.Resolvers.Abstractions;
using DotNetUltra.Services.Abstractions;
using Spectre.Console;
using System.Reflection;

namespace DotNetUltra.Services;

internal sealed class GreeterService(IWorkspaceResolver workspaceResolver) : IGreeterService
{
    private const int InitialYear = 2025;

    public void Execute()
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        if (executingAssembly == null)
        {
            return;
        }

        var possibleBuildDate = new FileInfo(executingAssembly.Location).LastWriteTime;
        var version = executingAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        var currentYear = DateTime.Now.Year;

        if (InitialYear == currentYear)
        {
            AnsiConsole.WriteLine($"DotNet Ultra (c) {InitialYear}");
        }
        else
        {
            AnsiConsole.WriteLine($"DotNet Ultra (c) {InitialYear} - {DateTime.Now.Year}");
        }


        if (!string.IsNullOrWhiteSpace(version))
        {
            AnsiConsole.WriteLine($"  Version:     {version,-20}");
        }

        AnsiConsole.WriteLine($"  Built:       {possibleBuildDate:yyyy-MM-dd HH:mm:ss}");
        AnsiConsole.WriteLine($"  Started:     {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        AnsiConsole.WriteLine($"  Workspace:   {workspaceResolver.GetWorkingDirectory()?.FullName ?? "No Workspace Found",-65}");

        if (workspaceResolver.IsSolutionDirectory())
        {
            AnsiConsole.WriteLine($"  Type:        Solution");
        }

        if (workspaceResolver.IsProjectDirectory())
        {
            AnsiConsole.WriteLine($"  Type:        Project");
        }
    }
}
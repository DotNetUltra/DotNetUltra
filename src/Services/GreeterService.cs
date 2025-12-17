using DotNetUltra.Services.Abstractions;
using Spectre.Console;
using System.Reflection;

namespace DotNetUltra.Services;

internal sealed class GreeterService(IWorkspaceService workspaceService) : IGreeterService
{
    private const int InitialYear = 2025;

    public void Greet()
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
        AnsiConsole.WriteLine($"  Workspace:   {workspaceService.GetWorkingDirectory()?.FullName ?? "No Workspace Found",-65}");

        if (workspaceService.IsSolutionDirectory())
        {
            AnsiConsole.WriteLine($"  Type:        Solution");
        }

        if (workspaceService.IsProjectDirectory())
        {
            AnsiConsole.WriteLine($"  Type:        Project");
        }
    }
}
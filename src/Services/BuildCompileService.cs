using DotNetUltra.Services.Abstractions;
using DotNetUltra.Utilities;
using DotNetUltra.Utilities.Abstractions;
using Spectre.Console;

namespace DotNetUltra.Services;

internal class BuildCompileService(IExternalProcessUtility externalProcessUtility) : IBuildCompileService
{
    public void Execute()
    {
        AnsiConsole.WriteLine($" Build Process Started");

        var result = externalProcessUtility.Execute(new ExternalProcessInput()
        {
            Application = ExternalProcessApplication.DotNet,
            Arguments = ["build"],
            ProcessTimeoutInMilliseconds = -1
        });

        if(result.ExitCode == 0)
        {
            AnsiConsole.WriteLine($" Build Process Finished Successfully");
        }
        else
        {
            AnsiConsole.WriteLine($" Build Process Finished with Errors");

            AnsiConsole.WriteLine(result.ExitCode);
            AnsiConsole.WriteLine(result?.Error ?? string.Empty);

            throw new Exception(result?.Error ?? string.Empty);
        }

        
    }
}

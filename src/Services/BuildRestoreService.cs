using DotNetUltra.Services.Abstractions;
using DotNetUltra.Utilities;
using DotNetUltra.Utilities.Abstractions;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Services;

internal class BuildRestoreService(IExternalProcessUtility externalProcessUtility) : IBuildRestoreService
{
    public void Execute()
    {
        var result = externalProcessUtility.Execute(new ExternalProcessInput()
        {
            Application = ExternalProcessApplication.DotNet,
            Arguments = ["restore"],
            ProcessTimeoutInMilliseconds = -1
        });


        if (result.ExitCode == 0)
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

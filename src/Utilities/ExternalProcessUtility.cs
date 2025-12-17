using DotNetUltra.Resolvers.Abstractions;
using DotNetUltra.Utilities.Abstractions;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotNetUltra.Utilities;

internal class ExternalProcessUtility(IWorkspaceResolver workspaceResolver) : IExternalProcessUtility
{
    public ExternalProcessResult Execute(ExternalProcessInput input)
    {
        var workingDirectory = workspaceResolver.GetWorkingDirectory().FullName;
        var processStartInfo = new ProcessStartInfo()
        {
            FileName = input.Application.ExecutableFileName,
            Arguments = input.ArgumentsToString,
            UseShellExecute = false,
            WorkingDirectory = workingDirectory,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };

        AnsiConsole.WriteLine($" Running '{input.Application.ExecutableFileName} {input.ArgumentsToString}' in '{workingDirectory}'");

        using var proc = new Process { StartInfo = processStartInfo };

        try
        {
            proc.StartInfo = processStartInfo;
            _ = proc.Start();

            var stdout = proc.StandardOutput.ReadToEnd();
            var stderr = proc.StandardError.ReadToEnd();

            _ = proc.WaitForExit(input.ProcessTimeoutInMilliseconds);

            var processExitCode = proc.ExitCode;

            proc.Close();

            return new ExternalProcessResult
            {
                ExitCode = processExitCode,
                Output = stdout,
                Error = stderr
            };
        }
        catch (Exception e)
        {
            return new ExternalProcessResult
            {
                ExitCode = 1,
                Output = e.StackTrace,
                Error = e.Message
            };
        }
    }
}

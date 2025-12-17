using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Services.Abstractions;

internal interface IWorkspaceService
{
    DirectoryInfo GetWorkingDirectory();
    public bool IsProjectDirectory();
    public bool IsSolutionDirectory();
}

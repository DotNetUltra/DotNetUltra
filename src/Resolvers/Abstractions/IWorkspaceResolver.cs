using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Resolvers.Abstractions;

internal interface IWorkspaceResolver
{
    DirectoryInfo GetWorkingDirectory();
    public bool IsProjectDirectory();
    public bool IsSolutionDirectory();
}

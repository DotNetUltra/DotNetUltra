using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Utilities.Abstractions;

internal interface IExternalProcessUtility
{
    ExternalProcessResult Execute(ExternalProcessInput input);
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetUltra.Pipelines.Abstractions;

internal interface IPipeline
{
    void Execute();
}

internal interface IPipeline<TPipelineExecuteInput>
    where TPipelineExecuteInput : class
{
    void Execute(TPipelineExecuteInput input);
}
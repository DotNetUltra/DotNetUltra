using DotNetUltra.Commands;
using DotNetUltra.Hosting;
using DotNetUltra.Pipelines;
using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Services;
using DotNetUltra.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;

namespace DotNetUltra;

class Program
{
    public static int Main(string[] args)
    {
        var registrations = new ServiceCollection();
        registrations
            .AddSingleton<IGreeterService, GreeterService>()
            .AddSingleton<IWorkspaceService, WorkspaceService>()
            .AddSingleton<IBuildCleanPipeline, BuildCleanPipeline>()
            ;

        var registrar = new DotNetUltraTypeRegistrar(registrations);

        var app = new CommandApp<DefaultCommand>(registrar);

        app.Configure(config =>
        {
            config.AddBranch("build", add =>
            {
                add.AddCommand<BuildCleanCommand>("clean");
            });
        });

        return app.Run(args);
    }
}

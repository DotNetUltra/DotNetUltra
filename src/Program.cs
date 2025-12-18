using DotNetUltra.Commands;
using DotNetUltra.Commands.BuildCommands;
using DotNetUltra.Commands.EFCoreCommands;
using DotNetUltra.Hosting;
using DotNetUltra.Hosting.Extensions;
using DotNetUltra.Pipelines;
using DotNetUltra.Pipelines.Abstractions;
using DotNetUltra.Resolvers;
using DotNetUltra.Resolvers.Abstractions;
using DotNetUltra.Services;
using DotNetUltra.Services.Abstractions;
using DotNetUltra.Utilities;
using DotNetUltra.Utilities.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;

namespace DotNetUltra;

class Program
{
    public static int Main(string[] args)
    {
        var registrations = new ServiceCollection()
            .AddDotNetUltra();

        var registrar = new DotNetUltraTypeRegistrar(registrations);

        var app = new CommandApp<DefaultCommand>(registrar);

        app.Configure(config =>
        {
            config.AddBranch("build", add =>
            {
                add.AddCommand<BuildCompileCommand>("compile");
                add.AddCommand<BuildCleanCommand>("clean");
                add.AddCommand<BuildCleanCommand>("restore");
                add.AddCommand<BuildFullCommand>("full");
            });

            config.AddBranch("efcore", add =>
            {
                add.AddBranch("migrations", addToEFCoreMigrations =>
                {
                    addToEFCoreMigrations.AddCommand<EFCoreMigrationsAddCommand>("add");
                    addToEFCoreMigrations.AddCommand<EFCoreMigrationsRemoveCommand>("remove");
                });
            });
        });

        return app.Run(args);
    }
}

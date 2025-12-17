namespace DotNetUltra.Utilities;

public class ExternalProcessApplication
{
    public required string ExecutableFileName { get; set; }
    public required string ExecutableDirectoryPath { get; set; }
    public static ExternalProcessApplication DotNet { get => _dotNet; set => _dotNet = value; }

    private static ExternalProcessApplication _dotNet = new()
    {
        ExecutableFileName = "dotnet",
        ExecutableDirectoryPath = ""
    };
}

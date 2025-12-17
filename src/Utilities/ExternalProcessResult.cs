namespace DotNetUltra.Utilities;

public class ExternalProcessResult
{
    public required int ExitCode { get; set; }
    public string? Output { get; set; }
    public string? Error { get; set; }
}

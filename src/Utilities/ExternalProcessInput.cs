namespace DotNetUltra.Utilities;

public class ExternalProcessInput
{
    public required ExternalProcessApplication Application { get; set; }
    public string[]? Arguments { get; set; }
    public string ArgumentsToString => string.Join(" ", Arguments ?? []);

    public int ProcessTimeoutInMilliseconds { get; set; } = -1;
}

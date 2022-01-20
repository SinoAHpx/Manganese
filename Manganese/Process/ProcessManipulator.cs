namespace Manganese.Process;

using System.Diagnostics;

public static class ProcessManipulator
{
    public static string? ReadOutputLine(this Process process)
    {
        return process.StandardOutput.ReadLine();
    }

    public static async Task<string?> ReadOutputLineAsync(this Process process)
    {
        return await process.StandardOutput.ReadLineAsync();
    }
}
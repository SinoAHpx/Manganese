namespace Manganese.Process;

using System.Diagnostics;

/// <summary>
/// Handle Process in a more convenient way
/// </summary>
public static class ProcessManipulator
{
    /// <summary>
    /// Read line from standard output if it exist
    /// </summary>
    /// <param name="process"></param>
    /// <returns></returns>
    public static string? ReadOutputLine(this Process process)
    {
        return process.StandardOutput.ReadLine();
    }

    /// <summary>
    /// Read line asynchronously from standard output if it exist
    /// </summary>
    /// <param name="process"></param>
    /// <returns></returns>
    public static async Task<string?> ReadOutputLineAsync(this Process process)
    {
        return await process.StandardOutput.ReadLineAsync();
    }
}
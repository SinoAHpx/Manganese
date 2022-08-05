using System.Runtime.InteropServices;

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

    /// <summary>
    /// Open some url in default browser
    /// </summary>
    /// <param name="uri"></param>
    public static void OpenUrl(this Uri uri)
    {
        uri.ToString().OpenUrl();
    }
    
    /// <summary>
    /// Open some url in default browser
    /// </summary>
    /// <param name="uri"></param>
    public static void OpenUrl(this string url)
    {
        try
        {
            Process.Start(url);
        }
        catch
        {
            // hack because of this: https://github.com/dotnet/corefx/issues/10361
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                throw;
            }
        }
    }
}
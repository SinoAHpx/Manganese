using System.Runtime.InteropServices;

namespace Manganese.Process;

using System.Diagnostics;

/// <summary>
/// Handle ProcessMolecule in a more convenient way
/// </summary>
public static class ProcessMolecule
{
    /// <summary>
    /// Read line from standard output if it exist
    /// </summary>
    /// <param name="process"></param>
    /// <returns></returns>
    public static string? ReadOutputLine(this System.Diagnostics.Process process)
    {
        return process.StandardOutput.ReadLine();
    }

    /// <summary>
    /// Read line asynchronously from standard output if it exist
    /// </summary>
    /// <param name="process"></param>
    /// <returns></returns>
    public static async Task<string?> ReadOutputLineAsync(this System.Diagnostics.Process process)
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
            System.Diagnostics.Process.Start(url);
        }
        catch
        {
            // hack because of this: https://github.com/dotnet/corefx/issues/10361
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                System.Diagnostics.Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                System.Diagnostics.Process.Start("open", url);
            }
            else
            {
                throw;
            }
        }
    }
}
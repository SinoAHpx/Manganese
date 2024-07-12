using System.Text;

namespace Manganese.IO;

/// <summary>
/// Handle FileInfo in a more convenient way
/// </summary>
public static class FileMolecule
{
    /// <summary>
    /// FileMolecule.WriteAllText with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="text"></param>
    public static void WriteAllText(this FileInfo file, string text)
    {
        System.IO.File.WriteAllText(file.FullName, text, new UTF8Encoding(false));
    }

    /// <summary>
    /// FileMolecule.ReadAllTextAsync
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static async Task<string> ReadAllTextAsync(this  FileInfo fileInfo)
    {
        return await System.IO.File.ReadAllTextAsync(fileInfo.FullName, new UTF8Encoding(false));
    }
    
    /// <summary>
    /// FileMolecule.ReadAllLinesAsync
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static async Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo)
    {
        return await System.IO.File.ReadAllLinesAsync(fileInfo.FullName, new UTF8Encoding(false));
    }
    
    /// <summary>
    /// FileMolecule.ReadAllBytesAsync
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static async Task<byte[]> ReadAllBytesAsync(this FileInfo fileInfo)
    {
        return await System.IO.File.ReadAllBytesAsync(fileInfo.FullName);
    } 

    /// <summary>
    /// FileMolecule.WriteAllTextAsync with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="text"></param>
    public static async Task WriteAllTextAsync(this FileInfo file, string text)
    {
        await System.IO.File.WriteAllTextAsync(file.FullName, text, new UTF8Encoding(false));
    }
    
        /// <summary>
    /// FileMolecule.WriteAllBytesAsync
    /// </summary>
    /// <param name="file"></param>
    /// <param name="bytes"></param>
    public static async Task WriteAllBytesAsync(this FileInfo file, byte[] bytes)
    {
        await System.IO.File.WriteAllBytesAsync(file.FullName, bytes);
    }
    
    
    /// <summary>
    /// FileMolecule.WriteAllLinesAsync with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="lines"></param>
    public static async Task WriteAllLineAsync(this FileInfo file, IEnumerable<string> lines)
    {
        await System.IO.File.WriteAllLinesAsync(file.FullName, lines, new UTF8Encoding(false));
    }

    /// <summary>
    /// FileMolecule.WriteAllBytes
    /// </summary>
    /// <param name="file"></param>
    /// <param name="bytes"></param>
    public static void WriteAllBytes(this FileInfo file, byte[] bytes)
    {
        System.IO.File.WriteAllBytes(file.FullName, bytes);
    }
    

    /// <summary>
    /// FileMolecule.WriteAllLines with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="lines"></param>
    public static void WriteAllLine(this FileInfo file, IEnumerable<string> lines)
    {
        System.IO.File.WriteAllLines(file.FullName, lines, new UTF8Encoding(false));
    }

    /// <summary>
    /// FileMolecule.ReadAllText
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static string ReadAllText(this FileInfo fileInfo)
    {
        return System.IO.File.ReadAllText(fileInfo.FullName, new UTF8Encoding(false));
    }

    /// <summary>
    /// FileMolecule.ReadAllLines
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static string[] ReadAllLines(this FileInfo fileInfo)
    {
        return System.IO.File.ReadAllLines(fileInfo.FullName, new UTF8Encoding(false));
    }


    /// <summary>
    /// FileMolecule.ReadAllBytes
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static byte[] ReadAllBytes(this FileInfo fileInfo)
    {
        return System.IO.File.ReadAllBytes(fileInfo.FullName);
    }

    /// <summary>
    /// An encapsulation of Path.GetFileName
    /// </summary>
    /// <param name="path"></param>
    /// <param name="withExtensionName"></param>
    /// <returns></returns>
    public static string GetFileName(this string path, bool withExtensionName = true)
    {
        return withExtensionName ? Path.GetFileName(path) : Path.GetFileNameWithoutExtension(path);
    }
}
using System.Text;

namespace Manganese.IO;

/// <summary>
/// Handle FileInfo in a more convenient way
/// </summary>
public static class FileInfoManipulator
{
    /// <summary>
    /// File.WriteAllText with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="text"></param>
    public static void WriteAllText(this FileInfo file, string text)
    {
        File.WriteAllText(file.FullName, text, new UTF8Encoding(false));
    }

    /// <summary>
    /// File.ReadAllTextAsync
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static async Task<string> ReadAllTextAsync(this  FileInfo fileInfo)
    {
        return await File.ReadAllTextAsync(fileInfo.FullName, new UTF8Encoding(false));
    }
    
    /// <summary>
    /// File.ReadAllLinesAsync
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static async Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo)
    {
        return await File.ReadAllLinesAsync(fileInfo.FullName, new UTF8Encoding(false));
    }
    
    /// <summary>
    /// File.ReadAllBytesAsync
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static async Task<byte[]> ReadAllBytesAsync(this FileInfo fileInfo)
    {
        return await File.ReadAllBytesAsync(fileInfo.FullName);
    } 

    /// <summary>
    /// File.WriteAllTextAsync with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="text"></param>
    public static async Task WriteAllTextAsync(this FileInfo file, string text)
    {
        await File.WriteAllTextAsync(file.FullName, text, new UTF8Encoding(false));
    }
    
        /// <summary>
    /// File.WriteAllBytesAsync
    /// </summary>
    /// <param name="file"></param>
    /// <param name="bytes"></param>
    public static async Task WriteAllBytesAsync(this FileInfo file, byte[] bytes)
    {
        await File.WriteAllBytesAsync(file.FullName, bytes);
    }
    
    
    /// <summary>
    /// File.WriteAllLinesAsync with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="lines"></param>
    public static async Task WriteAllLineAsync(this FileInfo file, IEnumerable<string> lines)
    {
        await File.WriteAllLinesAsync(file.FullName, lines, new UTF8Encoding(false));
    }

    /// <summary>
    /// File.WriteAllBytes
    /// </summary>
    /// <param name="file"></param>
    /// <param name="bytes"></param>
    public static void WriteAllBytes(this FileInfo file, byte[] bytes)
    {
        File.WriteAllBytes(file.FullName, bytes);
    }
    

    /// <summary>
    /// File.WriteAllLines with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="lines"></param>
    public static void WriteAllLine(this FileInfo file, IEnumerable<string> lines)
    {
        File.WriteAllLines(file.FullName, lines, new UTF8Encoding(false));
    }

    /// <summary>
    /// File.ReadAllText
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static string ReadAllText(this FileInfo fileInfo)
    {
        return File.ReadAllText(fileInfo.FullName, new UTF8Encoding(false));
    }

    /// <summary>
    /// File.ReadAllLines
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static string[] ReadAllLines(this FileInfo fileInfo)
    {
        return File.ReadAllLines(fileInfo.FullName, new UTF8Encoding(false));
    }


    /// <summary>
    /// File.ReadAllBytes
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public static byte[] ReadAllBytes(this FileInfo fileInfo)
    {
        return File.ReadAllBytes(fileInfo.FullName);
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
﻿using System.Text;

namespace Manganese.IO;

public static class FileInfoManipulator
{
    /// <summary>
    /// File.WriteAllText with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="text"></param>
    public static void WriteAllText(this FileInfo file, string text)
    {
        File.WriteAllText(file.FullName, text, Encoding.UTF8);
    }

#if NET6

    /// <summary>
    /// File.WriteAllTextAsync with UTF-8 encoding.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="text"></param>
    public static async Task WriteAllTextAsync(this FileInfo file, string text)
    {
        await File.WriteAllTextAsync(file.FullName, text, Encoding.UTF8);
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
        await File.WriteAllLinesAsync(file.FullName, lines);
    }
#endif


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
        File.WriteAllLines(file.FullName, lines, Encoding.UTF8);
    }
}
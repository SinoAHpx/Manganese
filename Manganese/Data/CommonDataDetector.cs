using System.Diagnostics.CodeAnalysis;

namespace Manganese.Data;

/// <summary>
/// General detector
/// </summary>
public static class CommonDataDetector
{
    /// <summary>
    /// Throw an exception if object is null 
    /// </summary>
    /// <param name="t"></param>
    /// <param name="exception"></param>
    /// <typeparam name="T">Target object</typeparam>
    /// <returns>Object itself</returns>
    public static T ThrowIfNull<T>(this T? t, Exception? exception = null)
    {
        if (t == null)
            throw exception ?? new InvalidOperationException("Object cannot be null");

        return t;
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Manganese.Array;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Manganese.Text;

/// <summary>
/// Check if a string is valid
/// </summary>
public static class StringDetector
{
    /// <summary>
    /// Check if a string is empty or whitespace.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty([NotNullWhen(returnValue: false)] this string? origin)
    {
        return string.IsNullOrWhiteSpace(origin);
    }

    /// <summary>
    /// Throw an exception if string is null or empty
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <typeparam name="T">Exception type</typeparam>
    /// <returns></returns>
    public static string ThrowIfNullOrEmpty<T>(this string? origin, string? message = null) where T : Exception, new()
    {
        if (origin.IsNullOrEmpty())
        {
            message ??= "String cannot be null";
            throw (Activator.CreateInstance(typeof(T), message) as T)!;
        }

        return origin;
    }

    /// <summary>
    /// Check if a string is valid int.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsInt32(this string? origin)
    {
        return int.TryParse(origin, out _);
    }

    /// <summary>
    /// Check if a string is valid long.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsInt64(this string? origin)
    {
        return long.TryParse(origin, out _);
    }

    /// <summary>
    /// Check if a string is valid double.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsDouble(this string? origin)
    {
        return double.TryParse(origin, out _);
    }

    /// <summary>
    /// Check if a string is valid float.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsFloat(this string? origin)
    {
        return float.TryParse(origin, out _);
    }

    /// <summary>
    /// Check if a string is valid decimal.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsDecimal(this string? origin)
    {
        return decimal.TryParse(origin, out _);
    }

    /// <summary>
    /// Throw if a string is not valid double.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static double ThrowIfNotDouble<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsDouble())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid double") as T)!;

        return double.Parse(origin);
    }

    /// <summary>
    /// Throw if a string is not valid float.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static float ThrowIfNotFloat<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsFloat())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid float") as T)!;

        return float.Parse(origin);
    }

    /// <summary>
    /// Throw if a string is not valid decimal.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static decimal ThrowIfNotDecimal<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsDecimal())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid decimal") as T)!;

        return decimal.Parse(origin);
    }

    /// <summary>
    /// Throw if a string is not valid int.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int ThrowIfNotInt32<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsInt32())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid integer") as T)!;

        return int.Parse(origin);
    }

    /// <summary>
    /// Throw if a string is not valid long.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static long ThrowIfNotInt64<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsInt64())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid long integer") as T)
                !;

        return long.Parse(origin);
    }

    /// <summary>
    /// Check if a string is valid json.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsValidJson(this string origin)
    {
        try
        {
            JsonConvert.DeserializeObject<object>(origin);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Throw if a string is not valid json document.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ThrowIfNotValidJson<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsValidJson())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid json") as T)!;

        return origin;
    }

    /// <summary>
    /// Check if a string is valid json object.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsJObject(this string origin)
    {
        try
        {
            JObject.Parse(origin);

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Check if a string is valid json array.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsJArray(this string origin)
    {
        try
        {
            JArray.Parse(origin);

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Throw if a string is not valid json object.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static JObject ThrowIfNotJObject<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsJObject())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid JObject") as T)!;

        return JObject.Parse(origin);
    }

    /// <summary>
    /// Throw if a string is not valid json array.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static JArray ThrowIfNotJArray<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsJArray())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid JArray") as T)!;

        return JArray.Parse(origin);
    }

    /// <summary>
    /// Check if a string is valid email address.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsValidEmail(this string origin)
    {
        return Regex.IsMatch(origin, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    }

    /// <summary>
    /// Throw if a string is not valid email address.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ThrowIfNotValidEmail<T>(this string origin, string? message = null) where T : Exception
    {
        if (!origin.IsValidEmail())
            throw (Activator.CreateInstance(typeof(T), message ?? $"{nameof(origin)} is not a valid email") as T)!;

        return origin;
    }

    /// <summary>
    /// "string".Contains() but extend to every single element in sequence
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool ContainsAnyOf(this string origin, params string[] t)
    {
        return t.Any(origin);
    }
    
    /// <summary>
    /// "string".Contains() but extend to every single element in sequence
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool ContainsAnyOf(this string origin, IEnumerable<string> t)
    {
        return t.Any(origin);
    }

    /// <summary>
    /// Check if a string is an integer
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsInteger(this string origin)
    {
        return origin.TrimStart('-').ToCharArray()
            .Select(x => x.ToString())
            .All(c => int.TryParse(c, out _));
    }
}
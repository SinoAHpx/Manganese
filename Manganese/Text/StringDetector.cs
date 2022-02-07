using System.Text.RegularExpressions;
using Manganese.Array;
using Newtonsoft.Json.Linq;

namespace Manganese.Text;

/// <summary>
/// Detectors for string.
/// </summary>
public static class StringDetector
{
    /// <summary>
    /// Check if a string is empty or whitespace.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="considerWhitespace">Whether if consider whitespaces as empty, default is false</param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string origin, bool considerWhitespace = false)
    {
        return considerWhitespace ? string.IsNullOrWhiteSpace(origin) : string.IsNullOrEmpty(origin);
    }

    /// <summary>
    /// Check if a string is null or whitespace.
    /// </summary>
    public static string ThrowIfNullOrEmpty(this string origin, string? message = null, bool considerWhitespace = false)
    {
        if (origin.IsNullOrEmpty(considerWhitespace))
            throw new ArgumentNullException(message ?? $"{nameof(origin)} cannot be null or empty");

        return origin;
    }
    
    /// <summary>
    /// Check if a string is valid int.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsInt32(this string origin)
    {
        return int.TryParse(origin, out _);
    }
    
    /// <summary>
    /// Check if a string is valid long.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsInt64(this string origin)
    {
        return long.TryParse(origin, out _);
    }

    /// <summary>
    /// Check if a string is valid double.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsDouble(this string origin)
    {
        return double.TryParse(origin, out _);
    }
    
    /// <summary>
    /// Check if a string is valid float.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsFloat(this string origin)
    {
        return float.TryParse(origin, out _);
    }
    
    /// <summary>
    /// Check if a string is valid decimal.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsDecimal(this string origin)
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
    public static double ThrowIfNotDouble(this string origin, string? message = null)
    {
        if (!origin.IsDouble())
            throw new ArgumentException(message ?? $"{nameof(origin)} is not a valid double");

        return double.Parse(origin);
    }
    
    /// <summary>
    /// Throw if a string is not valid float.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static float ThrowIfNotFloat(this string origin, string? message = null)
    {
        if (!origin.IsFloat())
            throw new ArgumentException(message ?? $"{nameof(origin)} is not a valid float");

        return float.Parse(origin);
    }
    
    /// <summary>
    /// Throw if a string is not valid decimal.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static decimal ThrowIfNotDecimal(this string origin, string? message = null)
    {
        if (!origin.IsDecimal())
            throw new ArgumentException(message ?? $"{nameof(origin)} is not a valid decimal");

        return decimal.Parse(origin);
    }

    /// <summary>
    /// Throw if a string is not valid int.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int ThrowIfNotInt32(this string origin, string? message = null)
    {
        if (!origin.IsInt32())
            throw new ArgumentException(message ?? $"{nameof(origin)} must be an integer");

        return int.Parse(origin);
    }
    
    /// <summary>
    /// Throw if a string is not valid long.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static long ThrowIfNotInt64(this string origin, string? message = null)
    {
        if (!origin.IsInt64())
            throw new ArgumentException(message ?? $"{nameof(origin)} must be an integer");

        return long.Parse(origin);
    }
    
    /// <summary>
    /// Check if a string is valid json.
    /// </summary>
    public static bool IsValidJson(this string origin)
    {
        return origin.IsJObject() || origin.IsJArray();
    }
    
    /// <summary>
    /// Throw if a string is not valid json document.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ThrowIfNotValidJson(this string origin, string? message = null)
    {
        if (!origin.IsValidJson())
            throw new ArgumentException(message ?? $"{nameof(origin)} must be a valid json");

        return origin;
    }
    
    /// <summary>
    /// Check if a string is valid json object.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsJObject(this string origin)
    {
        if (origin.StartsWith("{") && origin.EndsWith("}"))
            try
            {
                JObject.Parse(origin);

                return true;
            }
            catch
            {
                return false;
            }

        return false;
    }
    
    /// <summary>
    /// Check if a string is valid json array.
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static bool IsJArray(this string origin)
    {
        if (origin.StartsWith("[") && origin.EndsWith("]"))
            try
            {
                JArray.Parse(origin);

                return true;
            }
            catch
            {
                return false;
            }

        return false;
    }
    
    /// <summary>
    /// Throw if a string is not valid json object.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static JObject ThrowIfNotJObject(this string origin, string? message = null)
    {
        if (!origin.IsJObject())
            throw new ArgumentException(message ?? $"{nameof(origin)} must be a valid json object");

        return JObject.Parse(origin);
    }
    
    /// <summary>
    /// Throw if a string is not valid json array.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static JArray ThrowIfNotJArray(this string origin, string? message = null)
    {
        if (!origin.IsJArray())
            throw new ArgumentException(message ?? $"{nameof(origin)} must be a valid json array");

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
    public static string ThrowIfNotValidEmail(this string origin, string? message = null)
    {
        if (!origin.IsValidEmail())
            throw new ArgumentException(message ?? $"{nameof(origin)} must be a valid email address");

        return origin;
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
    /// <returns></returns>
    public static bool IsInteger(this string origin)
    {
        return origin.TrimStart('-').ToCharArray()
            .Select(x => x.ToString())
            .All(c => int.TryParse(c, out _));
    }
}
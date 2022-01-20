using System.Text.RegularExpressions;
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
    /// <param name="str"></param>
    /// <param name="considerWhitespace">Whether if consider whitespaces as empty, default is false</param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string str, bool considerWhitespace = false)
    {
        return considerWhitespace ? string.IsNullOrWhiteSpace(str) : string.IsNullOrEmpty(str);
    }

    /// <summary>
    /// Check if a string is null or whitespace.
    /// </summary>
    public static string ThrowIfNullOrEmpty(this string str, string? message = null, bool considerWhitespace = false)
    {
        if (str.IsNullOrEmpty(considerWhitespace))
            throw new ArgumentNullException(message ?? $"{nameof(str)} cannot be null or empty");

        return str;
    }
    
    /// <summary>
    /// Check if a string is valid int.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsInt32(this string str)
    {
        return int.TryParse(str, out _);
    }
    
    /// <summary>
    /// Check if a string is valid long.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsInt64(this string str)
    {
        return long.TryParse(str, out _);
    }

    /// <summary>
    /// Check if a string is valid double.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsDouble(this string str)
    {
        return double.TryParse(str, out _);
    }
    
    /// <summary>
    /// Check if a string is valid float.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsFloat(this string str)
    {
        return float.TryParse(str, out _);
    }
    
    /// <summary>
    /// Check if a string is valid decimal.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsDecimal(this string str)
    {
        return decimal.TryParse(str, out _);
    }
    
    /// <summary>
    /// Throw if a string is not valid double.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static double ThrowIfNotDouble(this string str, string? message = null)
    {
        if (!str.IsDouble())
            throw new ArgumentException(message ?? $"{nameof(str)} is not a valid double");

        return double.Parse(str);
    }
    
    /// <summary>
    /// Throw if a string is not valid float.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static float ThrowIfNotFloat(this string str, string? message = null)
    {
        if (!str.IsFloat())
            throw new ArgumentException(message ?? $"{nameof(str)} is not a valid float");

        return float.Parse(str);
    }
    
    /// <summary>
    /// Throw if a string is not valid decimal.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static decimal ThrowIfNotDecimal(this string str, string? message = null)
    {
        if (!str.IsDecimal())
            throw new ArgumentException(message ?? $"{nameof(str)} is not a valid decimal");

        return decimal.Parse(str);
    }

    /// <summary>
    /// Throw if a string is not valid int.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int ThrowIfNotInt32(this string str, string? message = null)
    {
        if (!str.IsInt32())
            throw new ArgumentException(message ?? $"{nameof(str)} must be an integer");

        return int.Parse(str);
    }
    
    /// <summary>
    /// Throw if a string is not valid long.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static long ThrowIfNotInt64(this string str, string? message = null)
    {
        if (!str.IsInt64())
            throw new ArgumentException(message ?? $"{nameof(str)} must be an integer");

        return long.Parse(str);
    }
    
    /// <summary>
    /// Check if a string is valid json.
    /// </summary>
    public static bool IsValidJson(this string str)
    {
        return str.IsJObject() || str.IsJArray();
    }
    
    /// <summary>
    /// Throw if a string is not valid json document.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ThrowIfNotValidJson(this string str, string? message = null)
    {
        if (!str.IsValidJson())
            throw new ArgumentException(message ?? $"{nameof(str)} must be a valid json");

        return str;
    }
    
    /// <summary>
    /// Check if a string is valid json object.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsJObject(this string str)
    {
        if (str.StartsWith("{") && str.EndsWith("}"))
            try
            {
                JObject.Parse(str);

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
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsJArray(this string str)
    {
        if (str.StartsWith("[") && str.EndsWith("]"))
            try
            {
                JArray.Parse(str);

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
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static JObject ThrowIfNotJObject(this string str, string? message = null)
    {
        if (!str.IsJObject())
            throw new ArgumentException(message ?? $"{nameof(str)} must be a valid json object");

        return JObject.Parse(str);
    }
    
    /// <summary>
    /// Throw if a string is not valid json array.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static JArray ThrowIfNotJArray(this string str, string? message = null)
    {
        if (!str.IsJArray())
            throw new ArgumentException(message ?? $"{nameof(str)} must be a valid json array");

        return JArray.Parse(str);
    }
    
    /// <summary>
    /// Check if a string is valid email address.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsValidEmail(this string str)
    {
        return Regex.IsMatch(str, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    }
    
    /// <summary>
    /// Throw if a string is not valid email address.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ThrowIfNotValidEmail(this string str, string? message = null)
    {
        if (!str.IsValidEmail())
            throw new ArgumentException(message ?? $"{nameof(str)} must be a valid email address");

        return str;
    }

    /// <summary>
    /// "string".Contains() but extend to every single element in sequence
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool ContainsAnyOf(this string s, IEnumerable<string> t)
    {
        return t.Any(s.Contains);
    }
}
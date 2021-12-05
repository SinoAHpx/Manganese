using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
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
    /// Check if a string is valid url.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsValidUrl(this string str)
    {
        return Regex.IsMatch(str, @"^(http|https|ftp|ws|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$");
    }
    
    /// <summary>
    /// Throw if a string is not valid url.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ThrowIfNotValidUrl(this string str, string? message = null)
    {
        if (!str.IsValidUrl())
            throw new ArgumentException(message ?? $"{nameof(str)} must be a valid url");

        return str;
    }
    
    /// <summary>
    /// Check if a string is valid ip address.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsValidIpAddress(this string str)
    {
        return Regex.IsMatch(str, @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
    }
    
    /// <summary>
    /// Throw if a string is not valid ip address.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string ThrowIfNotValidIpAddress(this string str, string? message = null)
    {
        if (!str.IsValidIpAddress())
            throw new ArgumentException(message ?? $"{nameof(str)} must be a valid ip address");

        return str;
    }
}
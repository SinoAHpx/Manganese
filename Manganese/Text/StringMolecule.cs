using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Manganese.Array;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Manganese.Text;

/// <summary>
/// Check if a string is valid
/// </summary>
public static class StringMolecule
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
            message ??= "StringMolecule cannot be null";
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

    #region Json

    /// <summary>
    /// Fetches value from a json with particular path
    /// </summary>
    /// <param name="json"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static JToken? FetchJToken(this string json, string path)
    {
        if (json.IsJArray())
            throw new ArgumentException("JArray could not be get");

        var obj = json.ThrowIfNotJObject<ArgumentException>("Is not a valid JObject");

        return obj.SelectToken(path);
    }

    /// <summary>
    /// Fetches value from a json with particular path
    /// </summary>
    /// <param name="json"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string? Fetch(this string json, string path)
    {
        return json.FetchJToken(path)?.ToString();
    }

    /// <summary>
    /// Fetches value from a json with particular path
    /// </summary>
    /// <param name="json"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static JToken? FetchJToken(this JToken json, string path)
    {
        return json.ToString().FetchJToken(path);
    }

    /// <summary>
    /// Fetches value from a json with particular path
    /// </summary>
    /// <param name="json"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string? Fetch(this JToken json, string path)
    {
        return json.ToString().Fetch(path);
    }

    /// <summary>
    /// Deserialize a string to a JSON object
    /// </summary>
    /// <param name="value"></param>
    /// <param name="nullValueHandling"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="JsonSerializationException"></exception>
    public static T? DeserializeTo<T>(this string value, NullValueHandling nullValueHandling = NullValueHandling.Include)
    {
        if (!value.IsValidJson())
            throw new JsonSerializationException("Invalid JSON");

        return JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings()
        {
            NullValueHandling = nullValueHandling
        });
    }

    /// <summary>
    /// Deserialize a string to a JSON object
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="JsonSerializationException"></exception>
    public static T? DeserializeTo<T>(this string value, JsonSerializerSettings settings)
    {
        if (!value.IsValidJson())
            throw new JsonSerializationException("Invalid JSON");

        return JsonConvert.DeserializeObject<T>(value, settings);
    }

    /// <summary>
    /// Convert a string to JObject. Exception will be occurred if it not. 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static JObject ToJObject(this string s)
    {
        return s.ThrowIfNullOrEmpty<ArgumentException>("A null or empty string can't be convert to json!")
            .ThrowIfNotJObject<ArgumentException>("Not a valid json string!");
    }

    /// <summary>
    /// Convert a string to JArray. Exception will be occurred if it not. 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static JArray ToJArray(this string s)
    {
        return s.ThrowIfNullOrEmpty<ArgumentNullException>("A null or empty string can't be convert to json!")
            .ThrowIfNotJArray<ArgumentNullException>("Not a valid json string!");
    }

    /// <summary>
    /// Serialize a object to JSON string
    /// </summary>
    /// <param name="t"></param>
    /// <param name="indented"></param>
    /// <param name="keepNullValue"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string ToJsonString<T>(this T t, bool indented = true, bool keepNullValue = true)
    {
        return JsonConvert.SerializeObject(t, new JsonSerializerSettings()
        {
            Formatting = indented ? Formatting.Indented : Formatting.None,
            NullValueHandling = keepNullValue ? NullValueHandling.Include : NullValueHandling.Ignore
        });
    }

    /// <summary>
    /// Serialize a object to JSON string
    /// </summary>
    /// <param name="t"></param>
    /// <param name="settings"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string ToJsonString<T>(this T t, JsonSerializerSettings settings)
    {
        return JsonConvert.SerializeObject(t, settings);
    }

    #endregion

    /// <summary>
    /// Convert string to int
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int ToInt32(this string s)
    {
        return int.Parse(s);
    }

    /// <summary>
    /// Convert string to long
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static long ToInt64(this string s)
    {
        return long.Parse(s);
    }

    /// <summary>
    /// Convert string to bool
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool ToBool(this string s)
    {
        return bool.Parse(s);
    }

    /// <summary>
    /// Remove all the invalid characters in a particular string
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string RemoveInvalidPathChars(this string s)
    {
        return Path.GetInvalidPathChars()
            .Aggregate(s, (current, c) => current.Replace(c.ToString(), string.Empty));
    }

    /// <summary>
    /// Remove all the invalid characters in a particular string
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string RemoveInvalidFileNameChars(this string s)
    {
        return Path.GetInvalidFileNameChars()
            .Aggregate(s, (current, c) => current.Replace(c.ToString(), string.Empty));
    }

    /// <summary>
    /// Path.Combine
    /// </summary>
    /// <param name="s"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public static string CombinePath(this string s, params string[] s2)
    {
        var list = new List<string> { s };

        return list.Concat(s2).Aggregate(Path.Combine);
    }

    /// <summary>
    /// string.Join but is an extension method
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="separator"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string JoinToString<T>(this IEnumerable<T> origin, string separator)
    {
        return string.Join(separator, origin.Select(x => x!.ToString()));
    }

    /// <summary>
    /// string.Join but is an extension method
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="separator"></param>
    /// <param name="selector">specified IEnumerable.Select() selector</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string JoinToString<T>(this IEnumerable<T> origin, string separator, Func<T, string> selector)
    {
        return string.Join(separator, origin.Select(selector));
    }

    /// <summary>
    /// Empty specified string in a string
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="toEmpty"></param>
    /// <returns></returns>
    public static string Empty(this string origin, string toEmpty)
    {
        return origin.Replace(toEmpty, string.Empty);
    }

    /// <summary>
    /// Substring between two string in this specified string
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="last">Start right string from last index of it</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string SubstringBetween(this string origin, string left, string right, bool last = false)
    {
        if (!origin.Contains(left) || !origin.Contains(right))
            throw new ArgumentException($"Argument does not exist in original string");

        var iLeft = origin.IndexOf(left, StringComparison.Ordinal) + left.Length;
        var iRight = last
            ? origin.LastIndexOf(right, StringComparison.Ordinal)
            : origin.IndexOf(right, StringComparison.Ordinal);

        return origin.Substring(iLeft, iRight - iLeft);
    }

    /// <summary>
    /// Substring after a string in specified string
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="left"></param>
    /// <param name="last">Start from last eligible string</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string SubstringAfter(this string origin, string left, bool last = false)
    {
        if (!origin.Contains(left))
            throw new ArgumentException($"Argument does not exist in original string");

        var iLeft = last
            ? origin.LastIndexOf(left, StringComparison.Ordinal) + left.Length
            : origin.IndexOf(left, StringComparison.Ordinal) + left.Length;

        return origin.Substring(iLeft);
    }

    /// <summary>
    /// Insert a string after specified string
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="left"></param>
    /// <param name="toInsert"></param>
    /// <param name="each">Insert after each matched string</param>
    /// <param name="last">Start from last matched string</param>
    /// <returns></returns>
    public static string InsertAfter(this string origin, string left, string toInsert, bool each = true, bool last = false)
    {
        if (each)
            return origin.Split(new[] { left }, StringSplitOptions.None).JoinToString($"{left}{toInsert}");

        var iLeft = last
            ? origin.LastIndexOf(left, StringComparison.Ordinal)
            : origin.IndexOf(left, StringComparison.Ordinal);

        return origin.Insert(iLeft + 1, toInsert);
    }

    /// <summary>
    /// Insert a string before specified string
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="right"></param>
    /// <param name="toInsert"></param>
    /// <param name="each">Insert before each matched string</param>
    /// <param name="last">Start from last matched string</param>
    /// <returns></returns>
    public static string InsertBefore(this string origin, string right, string toInsert, bool each = true, bool last = false)
    {
        if (each)
            return origin.Split(new[] { right }, StringSplitOptions.None).JoinToString($"{toInsert}{right}");

        var iRight = last
            ? origin.LastIndexOf(right, StringComparison.Ordinal)
            : origin.IndexOf(right, StringComparison.Ordinal);

        return origin.Insert(iRight, toInsert);
    }
}
using Newtonsoft.Json;

namespace Manganese.Text;

/// <summary>
/// Convert a string to particular types
/// </summary>
public static class StringConverter
{
    public static T? Deserialize<T>(string value)
    {
        return JsonConvert.DeserializeObject<T>(value);
    }
}
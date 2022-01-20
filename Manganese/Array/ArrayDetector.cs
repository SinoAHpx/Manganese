namespace Manganese.Array;

public static class ArrayDetector
{
    /// <summary>
    /// Check if a object is exist in a sequence
    /// </summary>
    /// <param name="t"></param>
    /// <param name="array"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsIn<T>(this T t, IEnumerable<T> array)
    {
        return array.Contains(t);
    }
}
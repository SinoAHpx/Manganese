namespace Manganese.Array;

/// <summary>
/// Methods for checking specified sequence
/// </summary>
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

    /// <summary>
    /// Check if a sequence has any of target value in
    /// </summary>
    /// <param name="sequence"></param>
    /// <param name="target"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool Any<T>(this IEnumerable<T> sequence, T target)
    {
        return sequence.Any(x => EqualityComparer<T>.Default.Equals(x, target));
    }
}
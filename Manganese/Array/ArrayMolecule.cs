namespace Manganese.Array;

/// <summary>
/// Handle specified sequence in a more convenient way
/// </summary>
public static class ArrayMolecule
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

    /// <summary>
    /// RemoveAll but return result
    /// </summary>
    /// <param name="sources"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> RemoveIf<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> predicate)
    {
        return sources.Where(x => !predicate(x));
    }
    
    /// <summary>
    /// RemoveRange but return result
    /// </summary>
    /// <param name="sources"></param>
    /// <param name="toRemove"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> Remove<TSource>(this IEnumerable<TSource> sources, IEnumerable<TSource> toRemove)
    {
        return sources.Where(t => !toRemove.Contains(t));
    }
    
    /// <summary>
    /// AddRange but return result
    /// </summary>
    /// <param name="sources"></param>
    /// <param name="toAdd"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> Add<TSource>(this IEnumerable<TSource> sources, IEnumerable<TSource> toAdd)
    {
        return sources.Concat(toAdd);
    }

    /// <summary>
    /// Output to console
    /// </summary>
    /// <param name="sources"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> Output<TSource>(this IEnumerable<TSource> sources)
    {
        var output = sources.ToList();
        
        Console.WriteLine($"[{output.Select(x => x!.ToString()).Aggregate((c, n) => $"{c}, {n}")}]");
        
        return output;
    }

    /// <summary>
    /// Output to console
    /// </summary>
    /// <param name="sources"></param>
    /// <param name="manipulator"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TSource> Output<TSource>(this IEnumerable<TSource> sources, Func<TSource, string> manipulator)
    {
        var output = sources.ToList();

        Console.WriteLine($"[{output.Select(manipulator).Aggregate((c, n) => $"{c}, {n}")}]");

        return output;
    }

    /// <summary>
    /// Return a random element
    /// </summary>
    /// <param name="origin"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static TSource Random<TSource>(this IEnumerable<TSource> origin)
    {
        var re = origin.ToList();
        var random = new Random();
        
        return re[random.Next(re.Count)];
    }

    /// <summary>
    /// Encapsulation of foreach statement
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="origin"></param>
    /// <param name="action"></param>
    public static void ForEach<TSource>(this IEnumerable<TSource> origin, Action<TSource> action)
    {
        foreach (var source in origin)
        {
            action(source);
        }
    }
}
﻿namespace Manganese.Array;

/// <summary>
/// Handle specified sequence in a more convenient way
/// </summary>
public static class ArrayManipulator
{
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
}
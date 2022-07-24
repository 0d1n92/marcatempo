using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace api.Extensions;

public static class IQueryableExtensions
{
    /// <summary>
    /// Returns the paginated query by given offset and page size
    /// </summary>
    /// <param name="elements">The source sequence</param>
    /// <param name="page">The page number</param>
    /// <param name="pageSize">The number of element to return</param>
    /// <returns>The paginated query if the offset and the pagesize have values; the query itself otherwise</returns>
    public static IQueryable<T> Paginate<T>(this IQueryable<T> elements, int? page, int? pageSize)
    {
        if (page.HasValue && pageSize.HasValue)
            return elements.Skip(page.Value * pageSize.Value).Take(pageSize.Value);
        else
            return elements;
    }

    /// <summary>
    /// Returns the filtered query by where clause only if the condition is true.
    /// </summary>
    /// <param name="query">The source sequence</param>
    /// <param name="condition">The condition to evaluate</param>
    /// <param name="whereClause">The where clause</param>
    /// <returns> The filtered query if the condition is true; the query itself otherwise</returns>
    public static IQueryable<T> Where<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> whereClause)
    {
        if (condition)
        {
            return query.Where(whereClause);
        }
        return query;
    }

    /// <summary>
    /// Sort one collection based on keys defined in another
    /// </summary>
    /// <returns>Items sorted</returns>
    public static IEnumerable<TResult> SortBy<TResult, TKey>(
        this IEnumerable<TResult> itemsToSort,
        IEnumerable<TKey> sortKeys,
        Func<TResult, TKey> matchFunc)
    {
        return sortKeys.Join(itemsToSort,
            key => key,
            matchFunc,
            (key, iitem) => iitem);
    }

    /// <summary>
    /// Shuffles a sequence of elements
    /// </summary>
    /// <param name="source">The sequence to shuffle</param>        
    /// <returns>The shuffled sequence</returns>
    public static IQueryable<T> Shuffle<T>(this IQueryable<T> source)
    {
        return source.OrderBy(x => Guid.NewGuid());
    }

    /// <summary>
    ///  Sorts the elements of a sequence in ascending or descending order according to a key.
    /// </summary>
    /// <param name="source">The source sequence</param>
    /// <param name="keySelector">The selector for the sort key</param>
    /// <param name="descending">The sorting order</param>
    /// <returns>An ordered queryable</returns>
    public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool descending)
    {
        return descending ? source.OrderByDescending(keySelector) : source.OrderBy(keySelector);
    }

    /// <summary>
    /// Performs a subsequent ordering of the elements in a sequence in ascending or descending order according to a key.
    /// </summary>
    /// <param name="source">The source sequence</param>
    /// <param name="keySelector">The selector for the sort key</param>
    /// <param name="descending">The sorting order</param>
    /// <returns>An ordered queryable</returns>
    public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool descending)
    {
        return descending ? source.ThenByDescending(keySelector) : source.ThenBy(keySelector);
    }

    /// <summary>
    /// Try to get max value of a given key. If an exception is thrown, returns the default specified value
    /// </summary>
    /// <param name="source">The source sequence</param>
    /// <param name="keySelector">The selector for the sort key</param>
    /// <param name="defaultValue">The default value</param>
    /// <returns>The max value of the requested key</returns>
    public static T GetMaxOrDefault<TSource, T>(this IQueryable<TSource> source, Expression<Func<TSource, T>> keySelector, T defaultValue)
    {
        try
        {
            return source.Max(keySelector);
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }
}
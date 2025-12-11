using System.Linq.Expressions;
using FX850P.Domain.Common;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Presistence.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<TType> ApplyOrdering<TType>(this IQueryable<TType> query, IQueryObject queryObj, Dictionary<string, Expression<Func<TType, object>>> columnsMap)
    {
        if (string.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.TryGetValue(queryObj.SortBy, out Expression<Func<TType, object>>? value))
        {
            return query;
        }

        if (queryObj.IsSortAscending)
        {
            return query.OrderBy(value);
        }
        else
        {
            return query.OrderByDescending(value);
        }
    }

    public static IQueryable<TType> ApplyPaging<TType>(this IQueryable<TType> query, IQueryObject queryObj)
    {
        if (queryObj.PageSize <= 0)
        {
            queryObj.PageSize = 10;
        }

        if (queryObj.Page <= 0)
        {
            queryObj.Page = 1;
        }

        return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
    }

    public static IQueryable<TTYpe> ApplyFiltering<TTYpe>(this IQueryable<TTYpe> query, Dictionary<bool, Expression<Func<TTYpe, bool>>> columns)
    {
        foreach (KeyValuePair<bool, Expression<Func<TTYpe, bool>>> column in columns)
        {
            Expression<Func<TTYpe, bool>> expression = column.Value;
            bool hasValue = column.Key;

            if (hasValue)
            {
                query = query.Where(expression);
            }
        }

        return query;
    }

    public static IQueryable<TType> ApplyFiltering<TType>(this IQueryable<TType> query, List<ColumnFilter<TType>> columns)
    {
        foreach (ColumnFilter<TType> column in columns)
        {
            if (column.HasValue)
            {
                query = query.Where(column.Expression);
            }
        }

        return query;
    }


}

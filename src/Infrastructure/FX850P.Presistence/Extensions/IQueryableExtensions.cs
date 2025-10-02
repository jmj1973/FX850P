using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FX850P.Domain.Common;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Presistence.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
    {
        if (string.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
        {
            return query;
        }

        if (queryObj.IsSortAscending)
        {
            return query.OrderBy(columnsMap[queryObj.SortBy]);
        }
        else
        {
            return query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }
    }

    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
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

    public static IQueryable<T> ApplyFiltering<T, M>(this IQueryable<T> query, M filter, Dictionary<bool, Expression<Func<T, bool>>> columns)
    {
        foreach (KeyValuePair<bool, Expression<Func<T, bool>>> column in columns)
        {
            Expression<Func<T, bool>> expression = column.Value;
            bool hasValue = column.Key;

            if (hasValue)
            {
                query = query.Where(expression);
            }
        }

        return query;
    }

    public static IQueryable<T> ApplyFiltering<T, M>(this IQueryable<T> query, M filter, List<ColumnFilter<T>> columns)
    {
        foreach (ColumnFilter<T> column in columns)
        {
            if (column.HasValue)
            {
                query = query.Where(column.Expression);
            }
        }

        return query;
    }


}

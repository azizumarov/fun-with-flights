using FWF.Core.Enums;
using FWF.Core.Helpers.QueryHelpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FWF.Dal.QueryableEstenstions
{
    public static class QueryableEstenstions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, PagingParameters pageParams)
        {
            if (pageParams.Skip != 0)
            {
                query = query.Skip(pageParams.Skip);
            }

            if (pageParams.Take != 0)
            {
                query = query.Take(pageParams.Take);
            }

            return query;
        }

        public static IQueryable<T> ApplyPagingAndSortingAnyObject<T>(this IQueryable<T> query, PagingParameters pagingParameters,
            SortInfo sortInfo) where T : class
        {
            if (!sortInfo.Equals(SortInfo.Empty))
            {
                Expression<Func<T, object>> sortingExpression = p => EF.Property<object>(p, sortInfo.SortBy);

                switch (sortInfo.Direction)
                {
                    case SortDirection.Asc:
                        query = query.OrderBy(sortingExpression);
                        break;
                    case SortDirection.Desc:
                        query = query.OrderByDescending(sortingExpression);
                        break;
                }
            }
            query = query.ApplyPaging(pagingParameters);

            return query;
        }
    }
}

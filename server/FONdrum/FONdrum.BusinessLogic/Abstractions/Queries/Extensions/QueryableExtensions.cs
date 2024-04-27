using FONdrum.DTO.Request;
using System.Linq.Expressions;

namespace FONdrum.BusinessLogic.Abstractions.Queries.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Page<TEntity>(this IQueryable<TEntity> query, PageParams pageParams)
            where TEntity : class
        {
            return query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize).Take(pageParams.PageSize);
        }

        public static IQueryable<TEntity> WhereIf<TEntity>(
            this IQueryable<TEntity> query, 
            Expression<Func<TEntity, bool>> predicate, bool condition
            )
            where TEntity : class
        {
            return condition ? query.Where(predicate) : query;
        }

        public static IQueryable<TEntity> If<TEntity>(
            this IQueryable<TEntity> query,
            bool condition,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> func
            )
            where TEntity : class
        {
            return condition ? func(query) : query;
        }
    }
}

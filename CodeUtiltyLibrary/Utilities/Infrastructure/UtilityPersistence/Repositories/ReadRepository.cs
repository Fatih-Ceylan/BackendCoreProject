using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Utilities.Core.UtilityApplication.Interfaces;
using Utilities.Core.UtilityDomain.Entities;

namespace Utilities.Infrastructure.UtilityPersistence.Repositories
{
    public class ReadRepository<DC, T> : IReadRepository<T> where T : BaseEntity where DC : DbContext
    {
        readonly DC _context;

        public ReadRepository(DC context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAllDesc(bool tracking = true)
        {
            var query = Table.OrderByDescending(x => x.CreatedDate).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAllDeletedStatus(bool tracking = true, bool isDeleted = false)
        {
            var query = Table.Where(x => x.IsDeleted == isDeleted).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAllDeletedStatusDesc(bool tracking = true, bool isDeleted = false)
        {
            var query = Table.Where(x => x.IsDeleted == isDeleted).OrderByDescending(x => x.CreatedDate).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAllIncluding(Expression<Func<T, object>>[] includeExpressions, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeExpressions != null && includeExpressions.Any())
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }

            return query;
        }

        public IQueryable<T> GetAllIncludingDesc(Expression<Func<T, object>>[] includeExpressions, bool tracking = true)
        {
            var query = Table.OrderByDescending(x => x.CreatedDate).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeExpressions != null && includeExpressions.Any())
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }

            return query;
        }

        public IQueryable<T> GetAllDeletedStatusIncluding(Expression<Func<T, object>>[] includeExpressions, bool tracking = true, bool isDeleted = false)
        {
            var query = Table.Where(x => x.IsDeleted == isDeleted).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeExpressions != null && includeExpressions.Any())
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }

            return query;
        }

        public IQueryable<T> GetAllDeletedStatusIncludingDesc(Expression<Func<T, object>>[] includeExpressions, bool tracking = true, bool isDeleted = false)
        {
            var query = Table.Where(x => x.IsDeleted == isDeleted).OrderByDescending(x => x.CreatedDate).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeExpressions != null && includeExpressions.Any())
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }

            return query;
        }


        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.Where(data => data.Id == Guid.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsyncIncluding(Expression<Func<T, object>>[] includeExpressions, string id, bool tracking = true)
        {
            var query = Table.Where(x => x.IsDeleted == false).AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeExpressions != null && includeExpressions.Any())
            {
                foreach (var includeExpression in includeExpressions)
                {
                    query = query.Include(includeExpression);
                }
            }

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true, bool isDeleted = false)
        {
            var query = Table.Where(method);
            query = query.Where(x => x.IsDeleted == isDeleted);
            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> SearchText(string keyword, bool tracking = true)
        {
            var properties = typeof(T).GetProperties()
                                      .Where(prop => prop.PropertyType == typeof(string));

            var parameter = Expression.Parameter(typeof(T), "s");
            var body = properties.Select(prop =>
                    (Expression)Expression.Call(
                        Expression.Property(parameter, prop),
                        "Contains",
                        null,
                        Expression.Constant(keyword)
                    )
                )
                .Aggregate((Expression)null, (current, next) =>
                    current == null ? next : Expression.OrElse(current, next)
                );

            var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);

            var query = Table.Where(predicate);
            query = query.Where(x => x.IsDeleted == false);

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
    }
}
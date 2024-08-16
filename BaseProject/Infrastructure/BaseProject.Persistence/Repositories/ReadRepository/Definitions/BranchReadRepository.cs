using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Persistence.Contexts;
using System.Linq.Expressions;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.ReadRepository.Definitions
{
    public class BranchReadRepository : ReadRepository<BaseProjectDbContext, Branch>, IBranchReadRepository
    {
        public BranchReadRepository(BaseProjectDbContext context) : base(context)
        {
        }

        public IQueryable<Branch> AddDynamicFilter<Branch>(IQueryable<Branch> query, string propertyName, string filterText)
        {
            var parameter = Expression.Parameter(typeof(Branch), "x");

            Expression propertyExpression = parameter;
            foreach (var property in propertyName.Split('.'))
            {
                propertyExpression = Expression.Property(propertyExpression, property);
            }

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var searchTextExpression = Expression.Constant(filterText);
            var containsCall = Expression.Call(propertyExpression, containsMethod, searchTextExpression);
            var lambda = Expression.Lambda<Func<Branch, bool>>(containsCall, parameter);

            return query.Where(lambda);
        }

        public IQueryable<Branch> AddDynamicFilterAll<Branch>(IQueryable<Branch> query, string propertyName, string filterText)
        {
            var parameter = Expression.Parameter(typeof(Branch), "x");
            var concatExpressions = new List<Expression>();

            foreach (var property in typeof(Branch).GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    var propertyAccess = Expression.Property(parameter, property);
                    concatExpressions.Add(propertyAccess);
                }
            }

            Expression propertyExpression = parameter;
            foreach (var property in propertyName.Split('.'))
            {
                propertyExpression = Expression.Property(propertyExpression, property);
            }

            concatExpressions.Add(propertyExpression);

            var concatMethod = typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string) });
            var emptyString = Expression.Constant("");
            var separator = Expression.Constant(" ");
            var concatCall = concatExpressions
                .Select(expression => Expression.Call(null, concatMethod, separator, expression))
                .Aggregate((x, y) => Expression.Call(null, concatMethod, x, y));
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var searchTextExpression = Expression.Constant(filterText);
            var containsCall = Expression.Call(concatCall, containsMethod, searchTextExpression);
            var lambda = Expression.Lambda<Func<Branch, bool>>(containsCall, parameter);

            return query.Where(lambda);
        }

        public IQueryable<Branch> FilteredBranch(string filterText, string? propertyName)
        {
            var query = GetAllDeletedStatusIncluding(new Expression<Func<Branch, object>>[] {
                                                                               b => b.Company
            }, false);

            query = propertyName != null ? AddDynamicFilterAll<Branch>(query, propertyName, filterText)
                                 : query.Where(b => b.Name.Contains(filterText) || b.Company.Name.Contains(filterText));

            return query;
        }
    }
}

using System.Linq.Expressions;
using Utilities.Core.UtilityDomain.Entities;

namespace Utilities.Core.UtilityApplication.Interfaces
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetAllDesc(bool tracking = true);

        IQueryable<T> GetAllDeletedStatus(bool tracking = true, bool isDeleted = false);

        IQueryable<T> GetAllDeletedStatusDesc(bool tracking = true, bool isDeleted = false);

        IQueryable<T> GetAllIncluding(Expression<Func<T, object>>[] includeExpressions, bool tracking = true);

        IQueryable<T> GetAllIncludingDesc(Expression<Func<T, object>>[] includeExpressions, bool tracking = true);

        IQueryable<T> GetAllDeletedStatusIncluding(Expression<Func<T, object>>[] includeExpressions, bool tracking = true, bool isDeleted = false);

        IQueryable<T> GetAllDeletedStatusIncludingDesc(Expression<Func<T, object>>[] includeExpressions, bool tracking = true, bool isDeleted = false);

        Task<T> GetByIdAsync(string id, bool tracking = true);

        Task<T> GetByIdAsyncIncluding(Expression<Func<T, object>>[] includeExpressions, string id, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true, bool isDeleted = false);

        IQueryable<T> SearchText(string keyword, bool tracking = true);

    }
}
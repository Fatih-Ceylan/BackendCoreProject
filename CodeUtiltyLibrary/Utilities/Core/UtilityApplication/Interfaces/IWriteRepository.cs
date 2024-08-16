using Utilities.Core.UtilityDomain.Entities;

namespace Utilities.Core.UtilityApplication.Interfaces
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> datas);

        bool SoftDelete(T model);

        bool SoftDeleteRange(List<T> datas);

        Task<bool> SoftDeleteAsync(string id);

        bool Update(T model);

        bool UpdateRange(List<T> model);

        Task<int> SaveAsync();
          
        bool HardDeleteRange(List<T> datas);

        bool HardDeleteById(string id);
    }
}
namespace GCharge.Application.Repositories.WriteRepository
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<T> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> datas);

        bool Update(T model);

        bool UpdateRange(List<T> model);

        Task<int> SaveAsync();

        bool HardDeleteRange(List<T> datas);
    }
}

using GCharge.Application.Repositories.WriteRepository;
using GCharge.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GCharge.Persistence.Repositories.WriteRepository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        readonly GChargeDbContext _context;

        public WriteRepository(GChargeDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.Entity;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool HardDeleteRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public bool UpdateRange(List<T> datas)
        {
            Table.UpdateRange(datas);
            return true;
        }
       
        public async Task<int> SaveAsync()
         => await _context.SaveChangesAsync();
    }
}

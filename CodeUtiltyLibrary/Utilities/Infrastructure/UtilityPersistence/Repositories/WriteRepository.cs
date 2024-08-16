using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Utilities.Core.UtilityApplication.Interfaces;
using Utilities.Core.UtilityDomain.Entities;

namespace Utilities.Infrastructure.UtilityPersistence.Repositories
{
    public class WriteRepository<DC, T> : IWriteRepository<T> where T : BaseEntity where DC : DbContext
    {
        readonly DC _context;

        public WriteRepository(DC context)
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

        public bool SoftDelete(T model)
        {
            model.IsDeleted = true;
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<bool> SoftDeleteAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            model.IsDeleted = true;
            EntityEntry<T> entityEntry = Table.Update(model);

            return entityEntry.State == EntityState.Modified;
        }

        public bool SoftDeleteRange(List<T> datas)
        {
            foreach (T data in datas)
            {
                data.IsDeleted = true;
            }
            Table.UpdateRange(datas);

            return true;
        } 

        public bool HardDeleteById(string id)
        {
            T model = Table.FirstOrDefault(data => data.Id == Guid.Parse(id));

            if (model != null)
            {
                Table.Remove(model); 
                return true;
            }
            else
            {
                return false;
            }
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
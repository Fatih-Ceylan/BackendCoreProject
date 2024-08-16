using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Microsoft.EntityFrameworkCore;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{
    public class EmployeeReadRepository : ReadRepository<BaseProjectDbContext, Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(BaseProjectDbContext context) : base(context)
        {
        }

        public async Task<Employee> GetByEmailAsync(string email, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(data => data.Email == email);
        }
    }
}

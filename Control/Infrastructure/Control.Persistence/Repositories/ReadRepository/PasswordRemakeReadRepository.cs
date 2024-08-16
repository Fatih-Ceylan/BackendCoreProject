using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Microsoft.EntityFrameworkCore;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{
    public class PasswordRemakeReadRepository : ReadRepository<BaseProjectDbContext, PasswordRemake>, IPasswordRemakeReadRepository
    {
        public PasswordRemakeReadRepository(BaseProjectDbContext context) : base(context)
        {
        }

        public async Task<PasswordRemake> GetByTokenAsync(string token, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Token == token);
        }
    }
}

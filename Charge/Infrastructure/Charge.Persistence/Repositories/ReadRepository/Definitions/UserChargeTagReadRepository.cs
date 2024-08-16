using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCharge.Persistence.Repositories.ReadRepository.Definitions
{
    public class UserChargeTagReadRepository : ReadRepository<GChargeDbContext, UserChargeTag>, IUserChargeTagReadRepository
    {
        public UserChargeTagReadRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}

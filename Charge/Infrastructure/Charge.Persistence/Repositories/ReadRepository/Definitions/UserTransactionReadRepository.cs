using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCharge.Persistence.Repositories.ReadRepository.Definitions
{
    internal class UserTransactionReadRepository : ReadRepository<GChargeDbContext, UserTransaction>, IUserTransactionReadRepository
    {
        public UserTransactionReadRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}

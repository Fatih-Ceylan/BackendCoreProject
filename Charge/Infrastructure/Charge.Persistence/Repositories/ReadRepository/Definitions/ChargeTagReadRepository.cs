using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;

namespace GCharge.Persistence.Repositories.ReadRepository.Definitions
{
    public class ChargeTagReadRepository : ReadRepository<ChargeTag>, IChargeTagReadRepository
    {
        public ChargeTagReadRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}
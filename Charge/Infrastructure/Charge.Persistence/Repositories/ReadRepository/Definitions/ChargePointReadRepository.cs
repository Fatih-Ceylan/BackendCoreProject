using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;

namespace GCharge.Persistence.Repositories.ReadRepository.Definitions
{
    public class ChargePointReadRepository : ReadRepository<ChargePoint>, IChargePointReadRepository
    {
        public ChargePointReadRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}

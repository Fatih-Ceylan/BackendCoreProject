using GCharge.Application.Repositories.WriteRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;

namespace GCharge.Persistence.Repositories.WriteRepository.Definitions
{
    public class ChargeTagWriteRepository : WriteRepository<ChargeTag>, IChargeTagWriteRepository
    {
        public ChargeTagWriteRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}
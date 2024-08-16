using GCharge.Application.Repositories.WriteRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCharge.Persistence.Repositories.WriteRepository.Definitions
{
    public class ElectricitySalesPriceWriteRepository : WriteRepository<GChargeDbContext, ElectricitySalesPrice>, IElectricitySalesPriceWriteRepository
    {
        public ElectricitySalesPriceWriteRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}
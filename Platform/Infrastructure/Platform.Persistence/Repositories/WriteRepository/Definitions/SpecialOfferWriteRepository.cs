using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class SpecialOfferWriteRepository : WriteRepository<PlatformDbContext, SpecialOffer>, ISpecialOfferWriteRepository
    {
        public SpecialOfferWriteRepository(PlatformDbContext context) : base(context)
        {
        }
    }
}

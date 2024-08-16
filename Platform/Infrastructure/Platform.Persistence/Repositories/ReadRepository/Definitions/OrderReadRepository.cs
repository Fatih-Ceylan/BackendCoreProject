using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.ReadRepository.Definitions
{
    public class OrderReadRepository: ReadRepository<PlatformDbContext, Order>, IOrderReadRepository
    {
        public OrderReadRepository(PlatformDbContext context) : base(context)
        {

        }
    }
}
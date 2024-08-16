using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.ReadRepository.Definitions
{
    public class OrderDetailReadRepository: ReadRepository<PlatformDbContext, OrderDetail>, IOrderDetailReadRepository
    {
        public OrderDetailReadRepository(PlatformDbContext context) : base(context)
        {

        }
    }
}

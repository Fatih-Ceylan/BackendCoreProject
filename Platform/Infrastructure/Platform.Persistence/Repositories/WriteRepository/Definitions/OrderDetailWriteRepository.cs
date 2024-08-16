using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class OrderDetailWriteRepository: WriteRepository<PlatformDbContext, OrderDetail>, IOrderDetailWriteRepository
    {
        public OrderDetailWriteRepository(PlatformDbContext context) : base(context)
        {

        }
    }
}
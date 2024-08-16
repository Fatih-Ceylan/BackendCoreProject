using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class OrderWriteRepository: WriteRepository<PlatformDbContext, Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(PlatformDbContext context) : base(context)
        {

        }
    }
}
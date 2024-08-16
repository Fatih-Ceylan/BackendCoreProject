using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.ReadRepository
{
    public class AddressReadRepository : ReadRepository<BaseProjectDbContext, Address>, IAddressReadRepository
    {
        public AddressReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

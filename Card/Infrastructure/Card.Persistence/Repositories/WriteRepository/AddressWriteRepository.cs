using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class AddressWriteRepository : WriteRepository<BaseProjectDbContext, Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

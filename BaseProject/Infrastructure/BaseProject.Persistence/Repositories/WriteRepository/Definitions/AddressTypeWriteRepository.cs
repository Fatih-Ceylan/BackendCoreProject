using BaseProject.Application.Repositories.WriteRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.WriteRepository.Definitions
{
    public class AddressTypeWriteRepository : WriteRepository<BaseProjectDbContext, AddressType>, IAddressTypeWriteRepository
    {
        public AddressTypeWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

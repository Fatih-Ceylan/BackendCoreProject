using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    internal class CustomerKindReadRepository : ReadRepository<BaseProjectDbContext, CustomerKind>, ICustomerKindReadRepository
    {
        public CustomerKindReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

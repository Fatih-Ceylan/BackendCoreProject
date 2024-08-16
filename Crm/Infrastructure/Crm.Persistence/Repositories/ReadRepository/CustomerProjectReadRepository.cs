using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    internal class CustomerProjectReadRepository : ReadRepository<BaseProjectDbContext, CustomerProject>, ICustomerProjectReadRepository
    {
        public CustomerProjectReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

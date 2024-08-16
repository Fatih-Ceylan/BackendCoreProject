using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public class CustomerSourceReadRepository : ReadRepository<BaseProjectDbContext, CustomerSource>, ICustomerSourceReadRepository
    {
        public CustomerSourceReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public class CustomerTypeReadRepository : ReadRepository<BaseProjectDbContext, CustomerType>, ICustomerTypeReadRepository
    {
        public CustomerTypeReadRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}

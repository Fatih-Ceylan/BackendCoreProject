using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public class CustomerStatusWriteRepository : WriteRepository<BaseProjectDbContext, CustomerStatus>, ICustomerStatusWriteRepository
    {
        public CustomerStatusWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

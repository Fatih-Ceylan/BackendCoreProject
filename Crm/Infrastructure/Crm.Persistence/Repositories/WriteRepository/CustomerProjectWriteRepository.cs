using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class CustomerProjectWriteRepository : WriteRepository<BaseProjectDbContext, CustomerProject>, ICustomerProjectWriteRepository
    {
        public CustomerProjectWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

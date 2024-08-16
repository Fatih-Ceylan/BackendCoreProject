using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers.Files;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository.Files;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository.Files
{
    public class CustomerFileWriteRepository : WriteRepository<BaseProjectDbContext, CustomerFile>, ICustomerFileWriteRepository
    {
        public CustomerFileWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

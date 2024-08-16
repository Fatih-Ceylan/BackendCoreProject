using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers.Files;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository.Files;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository.Files
{
    public class CustomerFileReadRepository : ReadRepository<BaseProjectDbContext, CustomerFile>, ICustomerFileReadRepository
    {
        public CustomerFileReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

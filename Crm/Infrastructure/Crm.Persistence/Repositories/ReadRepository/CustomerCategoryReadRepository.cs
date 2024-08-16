using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public class CustomerCategoryReadRepository : ReadRepository<BaseProjectDbContext, CustomerCategory>, ICustomerCategoryReadRepository
    {
        public CustomerCategoryReadRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}

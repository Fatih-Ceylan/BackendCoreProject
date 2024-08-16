using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public class CustomerAddressReadRepository : ReadRepository<BaseProjectDbContext, CustomerAddress>, ICustomerAddressReadRepository
    {
        public CustomerAddressReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
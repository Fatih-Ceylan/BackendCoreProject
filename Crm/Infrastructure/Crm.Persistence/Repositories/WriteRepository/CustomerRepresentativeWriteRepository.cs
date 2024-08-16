using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class CustomerRepresentativeWriteRepository : WriteRepository<BaseProjectDbContext, CustomerRepresentative>, ICustomerRepresentativeWriteRepository
    {
        public CustomerRepresentativeWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

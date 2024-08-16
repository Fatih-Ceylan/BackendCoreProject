using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public class CustomerKindWriteRepository : WriteRepository<BaseProjectDbContext, CustomerKind>, ICustomerKindWriteRepository
    {
        public CustomerKindWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

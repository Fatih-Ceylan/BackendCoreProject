using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Contacts;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public class CustomerContactWriteRepository : WriteRepository<BaseProjectDbContext, CustomerContact>, ICustomerContactWriteRepository
    {
        public CustomerContactWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }

}

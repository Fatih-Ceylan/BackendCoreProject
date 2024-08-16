using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Contacts;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public class CustomerContactReadRepository : ReadRepository<BaseProjectDbContext, CustomerContact>, ICustomerContactReadRepository
    {
        public CustomerContactReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

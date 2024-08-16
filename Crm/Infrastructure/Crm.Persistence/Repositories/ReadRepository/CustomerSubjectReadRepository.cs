using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class CustomerSubjectReadRepository : ReadRepository<BaseProjectDbContext, CustomerSubject>, ICustomerSubjectReadRepository
    {
        public CustomerSubjectReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

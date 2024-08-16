using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class CustomerActivityTypeWriteRepository : WriteRepository<BaseProjectDbContext, CustomerActivityType>, ICustomerActivityTypeWriteRepository
    {
        public CustomerActivityTypeWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

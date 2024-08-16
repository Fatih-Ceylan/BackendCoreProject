using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    internal class CustomerActivityReadRepository : ReadRepository<BaseProjectDbContext, CustomerActivity>, ICustomerActivityReadRepository
    {
        public CustomerActivityReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}


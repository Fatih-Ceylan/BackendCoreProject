using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class CustomerActivityTeamReadRepository : ReadRepository<BaseProjectDbContext, CustomerActivityTeam>, ICustomerActivityTeamReadRepository
    {
        public CustomerActivityTeamReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

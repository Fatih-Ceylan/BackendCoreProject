using BaseProject.Domain.Entities.GCrm.Definitions.UserManagement.Users;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class UsersReadRepository : ReadRepository<BaseProjectDbContext, Users>, IUsersReadRepository
    {
        public UsersReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

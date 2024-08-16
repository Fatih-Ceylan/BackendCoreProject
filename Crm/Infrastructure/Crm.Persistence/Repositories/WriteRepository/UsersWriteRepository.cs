using BaseProject.Domain.Entities.GCrm.Definitions.UserManagement.Users;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class UsersWriteRepository : WriteRepository<BaseProjectDbContext, Users>, IUsersWriteRepository
    {
        public UsersWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

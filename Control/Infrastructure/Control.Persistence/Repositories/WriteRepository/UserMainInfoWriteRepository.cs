using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class UserMainInfoWriteRepository : WriteRepository<BaseProjectDbContext, UserMainInfo>, IUserMainInfoWriteRepository
    {
        public UserMainInfoWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

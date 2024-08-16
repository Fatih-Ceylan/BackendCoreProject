using BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects.Files;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository.Files;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository.Files
{
    public class ProjectFileReadRepository : ReadRepository<BaseProjectDbContext, ProjectFiles>, IProjectFileReadRepository
    {
        public ProjectFileReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

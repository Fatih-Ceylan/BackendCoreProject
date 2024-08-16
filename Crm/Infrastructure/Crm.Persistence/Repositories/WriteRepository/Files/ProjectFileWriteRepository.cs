using BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects.Files;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository.Files;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository.Files
{
    public class ProjectFileWriteRepository : WriteRepository<BaseProjectDbContext, ProjectFiles>, IProjectFileWriteRepository
    {
        public ProjectFileWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

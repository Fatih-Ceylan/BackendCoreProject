using BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public class ProjectManagerReadRepository : ReadRepository<BaseProjectDbContext, ProjectManager>, IProjectManagerReadRepository
    {
        public ProjectManagerReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

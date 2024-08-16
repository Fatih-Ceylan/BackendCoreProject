using BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class ProjectWriteRepository : WriteRepository<BaseProjectDbContext, Project>, IProjectWriteRepository
    {
        public ProjectWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}

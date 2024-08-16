using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects
{
    public class ProjectManager : BaseEntity
    {
        public string ProjectManagerName { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}

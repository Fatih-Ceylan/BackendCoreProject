using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects
{
    public class ProjectType : BaseEntity
    {
        public string Name { get; set; } //proje tipi adı

        public ICollection<Project> Projects { get; set; }
    }
}

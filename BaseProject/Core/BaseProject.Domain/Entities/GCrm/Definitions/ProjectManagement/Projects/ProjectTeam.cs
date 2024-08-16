using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects
{
    public class ProjectTeam : BaseEntity
    {
        public string ProjectTeamName { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}

using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProjectTeam.GetAll
{
    public  class GetAllProjectTeamResponse
    {
        public int TotalCount { get; set; }

        public List<ProjectTeamVM>  ProjectTeams { get; set; }
    }
}

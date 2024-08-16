using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProjectManager.GetAll
{
    public  class GetAllProjectManagerResponse
    {
        public int TotalCount { get; set; }

        public List<ProjectManagerVM>  ProjectManagers { get; set; }
    }
}

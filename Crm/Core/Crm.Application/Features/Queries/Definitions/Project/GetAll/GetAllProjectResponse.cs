using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.Project.GetAll
{
    public  class GetAllProjectResponse
    {
        public int TotalCount { get; set; }

        public List<ProjectVM>  Projects { get; set; }
    }
}

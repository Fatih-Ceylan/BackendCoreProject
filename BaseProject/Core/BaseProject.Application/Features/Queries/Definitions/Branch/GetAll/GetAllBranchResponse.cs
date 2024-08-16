using BaseProject.Application.VMs.Definitions.Branch;

namespace BaseProject.Application.Features.Queries.Definitions.Branch.GetAll
{
    public class GetAllBranchResponse
    {
        public int TotalCount { get; set; }

        public List<BranchVM> Branches { get; set; }
    }
}
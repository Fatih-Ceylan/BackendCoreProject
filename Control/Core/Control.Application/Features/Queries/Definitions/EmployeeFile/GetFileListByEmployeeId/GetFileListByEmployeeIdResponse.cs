using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EmployeeFile.GetFileListByEmployeeId
{
    public class GetFileListByEmployeeIdResponse
    {
        public int TotalCount { get; set; }

        public List<EmployeeFileVM> Files { get; set; }
    }
}

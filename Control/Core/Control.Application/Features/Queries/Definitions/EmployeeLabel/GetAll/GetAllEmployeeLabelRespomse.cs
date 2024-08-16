using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.GetAll
{
    public class GetAllEmployeeLabelResponse
    {
        public int TotalCount { get; set; }

        public List<EmployeeLabelVM> EmployeeLabels { get; set; }
    }
}

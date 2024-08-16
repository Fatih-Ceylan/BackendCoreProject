using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.FilterField
{
    public class FilterFieldResponse
    {
        public int TotalCount { get; set; }

        public List<EmployeeLabelVM> EmployeeLabels { get; set; }
    }
}

using Utilities.Core.UtilityApplication.VMs;

namespace BaseProject.Application.VMs.Definitions
{
    public class DepartmentVM : BaseVM
    {
        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string BranchId { get; set; }

        public string BranchName { get; set; }

        public string Name { get; set; }

        public string? MainDepartmentId { get; set; }

        public string? MainDepartmentName { get; set; }
    }
}
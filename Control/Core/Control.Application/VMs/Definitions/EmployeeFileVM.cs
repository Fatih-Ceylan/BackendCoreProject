namespace GControl.Application.VMs.Definitions
{
    public class EmployeeFileVM
    {
        public string Id { get; set; }
        public string PathOrContainerName { get; set; }
        public string FileName { get; set; }
        public string Storage { get; set; }
        public string EmployeeId { get; set; }
        public string BaseProjectCompanyId { get; set; }
        public string? BaseProjectCompanyName { get; set; }
        public string BaseProjectBranchId { get; set; }
        public string? BaseProjectBranchName { get; set; }
    }
}

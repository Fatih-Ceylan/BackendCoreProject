namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class DepartmentDDLVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string BaseDepartmentId { get; set; }
        public string BaseDepartmentName { get; set; }
        public bool? isActive { get; set; }
        public int? EmployeeCount{ get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }
}

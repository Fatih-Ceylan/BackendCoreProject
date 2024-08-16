namespace BaseProject.Application.DTOs.Definitions.Department
{
    public class DepartmentDTO
    {
        public string Id { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string BranchId { get; set; }

        public string BranchName { get; set; }

        public string Name { get; set; }

        public string? MainDepartmentId { get; set; }

        public string? MainDepartmentName { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
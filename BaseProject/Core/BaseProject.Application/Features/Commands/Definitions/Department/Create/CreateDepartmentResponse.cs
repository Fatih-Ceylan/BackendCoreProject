namespace BaseProject.Application.Features.Commands.Definitions.Department.Create
{
    public class CreateDepartmentResponse
    {
        public string Id { get; set; }

        public string CompanyId { get; set; }

        public string BranchId { get; set; }

        public string Name { get; set; }

        public string? MainDepartmentId { get; set; }

        public string Message { get; set; }
    }
}
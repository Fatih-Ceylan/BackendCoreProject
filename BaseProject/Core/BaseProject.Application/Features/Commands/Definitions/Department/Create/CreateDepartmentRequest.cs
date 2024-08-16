using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.Department.Create
{
    public class CreateDepartmentRequest : IRequest<CreateDepartmentResponse>
    {
        public string CompanyId { get; set; }

        public string BranchId { get; set; }

        public string Name { get; set; }

        public string? MainDepartmentId { get; set; }

    }
}
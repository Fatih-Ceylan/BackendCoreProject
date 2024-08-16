using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Department.Create
{
    public class CreateDepartmentRequest : IRequest<CreateDepartmentResponse>
    {
        public string BaseDepartmentId { get; set; }
        public string LocationId { get; set; }
        public bool? isActive { get; set; } 
    }
}

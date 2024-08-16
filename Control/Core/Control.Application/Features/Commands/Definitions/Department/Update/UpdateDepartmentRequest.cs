using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Department.Update
{
    public class UpdateDepartmentRequest : IRequest<UpdateDepartmentResponse>
    {
        public string Id { get; set; }
        public string BaseDepartmentId { get; set; }
        public string LocationId { get; set; }
        public bool? isActive { get; set; } 
    }
}

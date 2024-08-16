using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.Department.Delete
{
    public class DeleteDepartmentRequest : IRequest<DeleteDepartmentResponse>
    {
        public string Id { get; set; }
    }
}
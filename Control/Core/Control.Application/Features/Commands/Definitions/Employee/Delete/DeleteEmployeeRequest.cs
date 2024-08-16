using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Employee.Delete
{
    public class DeleteEmployeeRequest : IRequest<DeleteEmployeeResponse>
    {
        public string Id { get; set; }
    }
}

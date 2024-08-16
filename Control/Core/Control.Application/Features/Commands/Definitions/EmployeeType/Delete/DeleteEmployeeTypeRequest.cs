using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeType.Delete
{
    public class DeleteEmployeeTypeRequest : IRequest<DeleteEmployeeTypeResponse>
    {
        public string Id { get; set; }
    }

}

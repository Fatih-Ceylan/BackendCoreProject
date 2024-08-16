using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Employee.Delete
{
    public class DeleteEmployeeRequest : IRequest<DeleteEmployeeResponse>
    {
        public string Id { get; set; }
    }
}

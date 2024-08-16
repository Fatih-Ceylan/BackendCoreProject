using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.Delete
{
    public class DeleteEmployeeLabelRequest : IRequest<DeleteEmployeeLabelResponse>
    {
        public string Id { get; set; }
    }
}

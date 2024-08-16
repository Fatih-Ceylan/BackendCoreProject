using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.Create
{
    public class CreateEmployeeLabelRequest : IRequest<CreateEmployeeLabelResponse>
    {
        public string Name { get; set; } 
    }
}

using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.Update
{
    public class UpdateEmployeeLabelRequest : IRequest<UpdateEmployeeLabelResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; } 
    }
}

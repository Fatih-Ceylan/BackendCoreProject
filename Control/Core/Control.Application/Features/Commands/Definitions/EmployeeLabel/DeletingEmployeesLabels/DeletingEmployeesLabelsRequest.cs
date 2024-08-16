using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.DeletingEmployeesLabels
{
    public class DeletingEmployeesLabelsRequest : IRequest<DeletingEmployeesLabelsResponse>
    {
        public List<string> EmployeesId { get; set; } = new List<string>();
        
    }
}

using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeType.Update
{
    public class UpdateEmployeeTypeRequest : IRequest<UpdateEmployeeTypeResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

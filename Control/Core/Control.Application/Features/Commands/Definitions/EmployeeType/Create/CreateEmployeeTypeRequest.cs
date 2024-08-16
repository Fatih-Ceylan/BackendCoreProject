using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeType.Create
{
    public class CreateEmployeeTypeRequest : IRequest<CreateEmployeeTypeResponse>
    {
        public string Name { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerType.Create
{
    public class CreateCustomerTypeRequest : IRequest<CreateCustomerTypeResponse>
    {
        public string Name { get; set; }

    }
}

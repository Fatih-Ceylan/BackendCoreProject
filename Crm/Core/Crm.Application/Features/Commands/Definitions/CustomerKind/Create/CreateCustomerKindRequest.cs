using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerKind.Create
{
    public class CreateCustomerKindRequest : IRequest<CreateCustomerKindResponse>
    {
        public string Name { get; set; }

    }
}

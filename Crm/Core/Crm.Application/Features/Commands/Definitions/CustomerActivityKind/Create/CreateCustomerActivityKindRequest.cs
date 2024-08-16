using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Create
{
    public class CreateCustomerActivityKindRequest : IRequest<CreateCustomerActivityKindResponse>
    {
        public string Name { get; set; }
    }
}

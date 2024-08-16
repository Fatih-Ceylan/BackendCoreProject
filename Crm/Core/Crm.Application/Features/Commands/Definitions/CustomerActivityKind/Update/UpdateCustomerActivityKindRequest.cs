using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Update
{
    public class UpdateCustomerActivityKindRequest : IRequest<UpdateCustomerActivityKindResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

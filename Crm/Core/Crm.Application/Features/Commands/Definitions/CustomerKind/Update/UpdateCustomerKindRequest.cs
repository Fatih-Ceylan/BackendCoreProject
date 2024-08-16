using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerKind.Update
{
    public class UpdateCustomerKindRequest : IRequest<UpdateCustomerKindResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }

    }
}

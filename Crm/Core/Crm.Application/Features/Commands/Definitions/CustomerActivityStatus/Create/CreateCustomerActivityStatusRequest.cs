using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Create
{
    public class CreateCustomerActivityStatusRequest : IRequest<CreateCustomerActivityStatusResponse>
    {
        public string Name { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Update
{
    public class UpdateCustomerActivityStatusRequest : IRequest<UpdateCustomerActivityStatusResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

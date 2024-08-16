using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerStatus.Update
{
    public class UpdateCustomerStatusRequest : IRequest<UpdateCustomerStatusResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}

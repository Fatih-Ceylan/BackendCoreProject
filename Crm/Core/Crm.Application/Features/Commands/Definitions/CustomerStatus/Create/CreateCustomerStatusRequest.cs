using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerStatus.Create
{
    public class CreateCustomerStatusRequest : IRequest<CreateCustomerStatusResponse>
    {
        public string Name { get; set; }
    }
}

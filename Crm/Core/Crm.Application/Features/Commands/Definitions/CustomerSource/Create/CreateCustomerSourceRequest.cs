using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSource.Create
{
    public class CreateCustomerSourceRequest : IRequest<CreateCustomerSourceResponse>
    {
        public string Name { get; set; }
    }
}

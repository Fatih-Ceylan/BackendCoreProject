using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSource.Update
{
    public class UpdateCustomerSourceRequest : IRequest<UpdateCustomerSourceResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}

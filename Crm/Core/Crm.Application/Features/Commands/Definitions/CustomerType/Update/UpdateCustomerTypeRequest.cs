using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerType.Update
{
    public class UpdateCustomerTypeRequest : IRequest<UpdateCustomerTypeResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}

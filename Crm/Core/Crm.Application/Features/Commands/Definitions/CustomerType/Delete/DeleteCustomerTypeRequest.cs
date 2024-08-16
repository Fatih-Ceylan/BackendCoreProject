using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerType.Delete
{
    public class DeleteCustomerTypeRequest : IRequest<DeleteCustomerTypeResponse>
    {
        public string Id { get; set; }
    }
}

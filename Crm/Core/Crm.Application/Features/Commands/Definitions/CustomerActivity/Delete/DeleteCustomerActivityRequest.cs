using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivity.Delete
{
    public class DeleteCustomerActivityRequest : IRequest<DeleteCustomerActivityResponse>
    {
        public string Id { get; set; }
    }
}

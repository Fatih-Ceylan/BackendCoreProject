using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerGroup.Delete
{
    public  class DeleteCustomerGroupRequest : IRequest<DeleteCustomerGroupResponse>
    {
        public string Id { get; set; }
    }
}

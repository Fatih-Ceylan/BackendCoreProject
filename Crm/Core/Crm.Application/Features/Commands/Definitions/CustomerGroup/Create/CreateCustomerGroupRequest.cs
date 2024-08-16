using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerGroup.Create
{
    public  class CreateCustomerGroupRequest : IRequest<CreateCustomerGroupResponse>
    {
        public string CustomerGroupName { get; set; }
        public string CustomerGroupType { get; set; }   
    }
}

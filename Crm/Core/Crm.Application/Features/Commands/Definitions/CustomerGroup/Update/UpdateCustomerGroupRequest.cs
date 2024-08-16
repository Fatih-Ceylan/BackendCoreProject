using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerGroup.Update
{
    public  class UpdateCustomerGroupRequest : IRequest<UpdateCustomerGroupResponse>
    {
        public string Id { get; set; }
        public string CustomerGroupName { get; set; }
        public string CustomerGroupType { get; set; }
      
    }
}

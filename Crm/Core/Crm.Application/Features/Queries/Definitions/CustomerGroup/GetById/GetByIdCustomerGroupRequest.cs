using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerGroup.GetById
{
    public  class GetByIdCustomerGroupRequest : IRequest<GetByIdCustomerGroupResponse>
    {
        public string Id { get; set; }
    }
}

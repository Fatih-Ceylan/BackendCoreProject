using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerGroup.GetById
{
    public  class GetByIdCustomerGroupHandler : IRequestHandler<GetByIdCustomerGroupRequest,GetByIdCustomerGroupResponse>
    {
        readonly ICustomerGroupReadRepository _customerGroupReadRepository;

        public GetByIdCustomerGroupHandler(ICustomerGroupReadRepository customerGroupReadRepository)
        {
            _customerGroupReadRepository = customerGroupReadRepository;
        }

        public async  Task<GetByIdCustomerGroupResponse> Handle(GetByIdCustomerGroupRequest request, CancellationToken cancellationToken)
        {
            var customerGroup = _customerGroupReadRepository
                         .GetWhere(cg => cg.Id == Guid.Parse(request.Id), false)
                           .Select(cg => new CustomerGroupVM
                           {
                               Id = cg.Id.ToString(),
                               CustomerGroupName = cg.CustomerGroupName,
                               CustomerGroupType = cg.CustomerGroupType,                                                      
                             
                               CreatedDate = cg.CreatedDate
                           }).FirstOrDefault();

            return new()
            {
                CustomerGroup = customerGroup
            };
        }
    }
}

using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerGroup.GetAll
{
    public class GetAllCustomerGroupHandler : IRequestHandler<GetAllCustomerGroupRequest, GetAllCustomerGroupResponse>
    {
        readonly ICustomerGroupReadRepository _customerGroupReadRepository;
        public GetAllCustomerGroupHandler(ICustomerGroupReadRepository customerGroupReadRepository)
        {
            _customerGroupReadRepository = customerGroupReadRepository;
        }

        public Task<GetAllCustomerGroupResponse> Handle(GetAllCustomerGroupRequest request, CancellationToken cancellationToken)
        {
            var query = _customerGroupReadRepository
                        .GetAllDeletedStatusDesc(false)
                        .Select(cg => new CustomerGroupVM
                        {
                            Id = cg.Id.ToString(),
                            CustomerGroupName = cg.CustomerGroupName,
                            CustomerGroupType = cg.CustomerGroupType
                           
                        });

            var totalCount = query.Count();
            var customerGroups = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerGroupResponse
            {
                TotalCount = totalCount,
                CustomerGroups = customerGroups,
            });
        }
    }
}

using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerStatus.GetAll
{
    public class GetAllCustomerStatusHandler : IRequestHandler<GetAllCustomerStatusRequest, GetAllCustomerStatusResponse>
    {
        readonly ICustomerStatusReadRepository _customerStatusReadRepository;

        public GetAllCustomerStatusHandler(ICustomerStatusReadRepository customerStatusReadRepository)
        {
            _customerStatusReadRepository = customerStatusReadRepository;
        }

        public Task<GetAllCustomerStatusResponse> Handle(GetAllCustomerStatusRequest request, CancellationToken cancellationToken)
        {
            var query = _customerStatusReadRepository.GetAllDeletedStatusDesc(false)
                        .Select(ca => new CustomerStatusVM
                        {
                            Id = ca.Id.ToString(),
                            Name = ca.Name,
                            CreatedDate = ca.CreatedDate
                        });
            var totalCount = query.Count();
            var customersStatus = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerStatusResponse
            {
                TotalCount = totalCount,
                CustomersStatus = customersStatus,
            });
        }
    }
}

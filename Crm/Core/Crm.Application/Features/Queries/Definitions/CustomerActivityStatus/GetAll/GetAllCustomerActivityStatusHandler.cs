using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityStatus.GetAll
{
    public class GetAllCustomerActivityStatusHandler : IRequestHandler<GetAllCustomerActivityStatusRequest, GetAllCustomerActivityStatusResponse>
    {

        readonly ICustomerActivityStatusReadRepository _customerActivityStatusReadRepository;

        public GetAllCustomerActivityStatusHandler(ICustomerActivityStatusReadRepository customerActivityStatusReadRepository)
        {
            _customerActivityStatusReadRepository = customerActivityStatusReadRepository;
        }

        public Task<GetAllCustomerActivityStatusResponse> Handle(GetAllCustomerActivityStatusRequest request, CancellationToken cancellationToken)
        {
            var query = _customerActivityStatusReadRepository.GetAllDeletedStatusDesc(false)
               .Select(cas => new CustomerActivityStatusVM
               {
                   Id = cas.Id.ToString(),
                   Name = cas.Name,
                   CreatedDate = cas.CreatedDate,
               });

            var totalCount = query.Count();
            var customeractivitystatues = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerActivityStatusResponse
            {
                TotalCount = totalCount,
                customerActivityStatuses = customeractivitystatues,
            });
        }
    }
}

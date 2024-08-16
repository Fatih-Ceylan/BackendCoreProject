using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityKind.GetAll
{
    public class GetAllCustomerActivityKindHandler : IRequestHandler<GetAllCustomerActivityKindRequest, GetAllCustomerActivityKindResponse>
    {
        readonly ICustomerActivityKindReadRepository _customerActivityKindReadRepository;

        public GetAllCustomerActivityKindHandler(ICustomerActivityKindReadRepository customerActivityKindReadRepository)
        {
            _customerActivityKindReadRepository = customerActivityKindReadRepository;
        }

        public Task<GetAllCustomerActivityKindResponse> Handle(GetAllCustomerActivityKindRequest request, CancellationToken cancellationToken)
        {
                var query = _customerActivityKindReadRepository.GetAllDeletedStatusDesc(false)
                .Select(cak => new CustomerActivityKindVM
                {
                    Id = cak.Id.ToString(),                
                    Name = cak.Name,                            
                    CreatedDate = cak.CreatedDate,
                });

            var totalCount = query.Count();
            var customeractivitykinds = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerActivityKindResponse
            {
                TotalCount = totalCount,
                customerActivityKinds = customeractivitykinds,
            });
        }
    }
}

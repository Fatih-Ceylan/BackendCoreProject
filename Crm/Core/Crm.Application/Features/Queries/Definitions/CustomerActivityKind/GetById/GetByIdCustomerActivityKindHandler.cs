using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityKind.GetById
{
    public class GetByIdCustomerActivityKindHandler : IRequestHandler<GetByIdCustomerActivityKindRequest, GetByIdCustomerActivityKindResponse>
    {
        readonly ICustomerActivityKindReadRepository _customerActivityKindReadRepository;

        public GetByIdCustomerActivityKindHandler(ICustomerActivityKindReadRepository customerActivityKindReadRepository)
        {
            _customerActivityKindReadRepository = customerActivityKindReadRepository;
        }

        public async  Task<GetByIdCustomerActivityKindResponse> Handle(GetByIdCustomerActivityKindRequest request, CancellationToken cancellationToken)
        {
            var customeractivitykind = _customerActivityKindReadRepository
                       .GetWhere(cak => cak.Id == Guid.Parse(request.Id), false)
                       .Select(cak => new CustomerActivityKindVM
                       {
                           Id = cak.Id.ToString(),                          
                           Name = cak.Name,                        
                           CreatedDate = cak.CreatedDate
                       }).FirstOrDefault();

            return new()
            {
                customerActivityKind = customeractivitykind
            };
        }
    }
}

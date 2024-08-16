using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityType.GetAll
{
    public class GetAllCustomerActivityTypeHandler : IRequestHandler<GetAllCustomerActivityTypeRequest, GetAllCustomerActivityTypeResponse>
    {

        readonly ICustomerActivityTypeReadRepository _customerActivityTypeReadRepository;

        public GetAllCustomerActivityTypeHandler(ICustomerActivityTypeReadRepository customerActivityTypeReadRepository)
        {
            _customerActivityTypeReadRepository = customerActivityTypeReadRepository;
        }

        public   Task<GetAllCustomerActivityTypeResponse> Handle(GetAllCustomerActivityTypeRequest request, CancellationToken cancellationToken)
        {
            var query = _customerActivityTypeReadRepository.GetAllDeletedStatusDesc(false)
               .Select(ct => new CustomerActivityTypeVM
               {
                   Id = ct.Id.ToString(),
                   Name = ct.Name,
                   CreatedDate = ct.CreatedDate,
               });

            var totalCount = query.Count();
            var customeractivitytypes = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerActivityTypeResponse
            {
                TotalCount = totalCount,
                customerActivityTypes = customeractivitytypes,
            });
        }
    }
}

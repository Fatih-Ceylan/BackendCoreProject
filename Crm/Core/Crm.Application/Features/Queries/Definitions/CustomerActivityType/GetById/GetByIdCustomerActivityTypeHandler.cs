using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityType.GetById
{
    public class GetByIdCustomerActivityTypeHandler : IRequestHandler<GetByIdCustomerActivityTypeRequest, GetByIdCustomerActivityTypeResponse>
    {
        readonly ICustomerActivityTypeReadRepository _customerActivityTypeReadRepository;

        public GetByIdCustomerActivityTypeHandler(ICustomerActivityTypeReadRepository customerActivityTypeReadRepository)
        {
            _customerActivityTypeReadRepository = customerActivityTypeReadRepository;
        }

        public async  Task<GetByIdCustomerActivityTypeResponse> Handle(GetByIdCustomerActivityTypeRequest request, CancellationToken cancellationToken)
        {
            var customeractivitytype = _customerActivityTypeReadRepository
                           .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                           .Select(ct => new CustomerActivityTypeVM
                           {
                               Id = ct.Id.ToString(),
                               Name = ct.Name,                                                 
                               CreatedDate = ct.CreatedDate
                           }).FirstOrDefault();



            return new()
            {
                customerActivityTypeVM = customeractivitytype
            };
        }
    }
}

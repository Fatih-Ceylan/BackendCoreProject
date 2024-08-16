using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityStatus.GetById
{
    public class GetByIdCustomerActivityStatusHandler : IRequestHandler<GetByIdCustomerActivityStatusRequest, GetByIdCustomerActivityStatusResponse>
    {
        readonly ICustomerActivityStatusReadRepository _customerActivityStatusReadRepository;

        public GetByIdCustomerActivityStatusHandler(ICustomerActivityStatusReadRepository customerActivityStatusReadRepository)
        {
            _customerActivityStatusReadRepository = customerActivityStatusReadRepository;
        }

        public async  Task<GetByIdCustomerActivityStatusResponse> Handle(GetByIdCustomerActivityStatusRequest request, CancellationToken cancellationToken)
        {
            var customeractivitystatus = _customerActivityStatusReadRepository
                          .GetWhere(cas => cas.Id == Guid.Parse(request.Id), false)
                          .Select(cas => new CustomerActivityStatusVM
                          {
                              Id = cas.Id.ToString(),
                              Name=cas.Name,
                      

                              CreatedDate = cas.CreatedDate
                          }).FirstOrDefault();



            return new()
            {
                customerActivityStatus = customeractivitystatus
            };
        }
    }
}

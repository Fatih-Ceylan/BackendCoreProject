using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerStatus.GetById
{
    public class GetByIdCustomerStatusHandler : IRequestHandler<GetByIdCustomerStatusRequest, GetByIdCustomerStatusResponse>
    {
        readonly ICustomerStatusReadRepository _customerStatusReadRepository;
        readonly IMapper _mapper;

        public GetByIdCustomerStatusHandler(ICustomerStatusReadRepository customerStatusReadRepository, IMapper mapper)
        {
            _customerStatusReadRepository = customerStatusReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCustomerStatusResponse> Handle(GetByIdCustomerStatusRequest request, CancellationToken cancellationToken)
        {
            var customerStatus = _customerStatusReadRepository
                                      .GetWhere(cc => cc.Id == Guid.Parse(request.Id), false)
                                      .Select(cc => new CustomerStatusVM
                                      {
                                          Id = cc.Id.ToString(),
                                          Name = cc.Name,
                                          CreatedDate = cc.CreatedDate
                                      }).FirstOrDefault();

            return new()
            {
                CustomerStatus = customerStatus
            };
        }
    }
}

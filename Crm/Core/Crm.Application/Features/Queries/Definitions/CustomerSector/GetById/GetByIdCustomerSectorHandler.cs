using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSector.GetById
{
    public class GetByIdCustomerSectorHandler : IRequestHandler<GetByIdCustomerSectorRequest, GetByIdCustomerSectorResponse>
    {
        readonly ICustomerSectorReadRepository _customerSectorReadRepository;

        public GetByIdCustomerSectorHandler(ICustomerSectorReadRepository customerSectorReadRepository)
        {
            _customerSectorReadRepository = customerSectorReadRepository;
        }

        public async Task<GetByIdCustomerSectorResponse> Handle(GetByIdCustomerSectorRequest request, CancellationToken cancellationToken)
        {
            var customerSector = _customerSectorReadRepository
                                   .GetWhere(cs => cs.Id == Guid.Parse(request.Id), false)
                                   .Select(cs => new CustomerSectorVM
                                   {
                                       Id = cs.Id.ToString(),
                                       Name = cs.Name,
                                   }).FirstOrDefault();

            return new()
            {
                CustomerSector = customerSector
            };
        }
    }
}
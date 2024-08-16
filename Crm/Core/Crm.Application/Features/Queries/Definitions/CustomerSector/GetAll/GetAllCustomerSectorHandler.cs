using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSector.GetAll
{
    public class GetAllCustomerSectorHandler : IRequestHandler<GetAllCustomerSectorRequest, GetAllCustomerSectorResponse>
    {
        readonly ICustomerSectorReadRepository _customerSectorReadRepository;

        public GetAllCustomerSectorHandler(ICustomerSectorReadRepository customerSectorReadRepository)
        {
            _customerSectorReadRepository = customerSectorReadRepository;
        }

        public Task<GetAllCustomerSectorResponse> Handle(GetAllCustomerSectorRequest request, CancellationToken cancellationToken)
        {
            var query = _customerSectorReadRepository
                                    .GetAllDeletedStatusDesc(false)
                                    .Select(cs => new CustomerSectorVM
                                    {
                                        Id = cs.Id.ToString(),
                                        Name = cs.Name,
                                    });

            var totalCount = query.Count();
            var customersSectors = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerSectorResponse
            {
                TotalCount = totalCount,
                CustomerSectors = customersSectors,
            });
        }
    }
}
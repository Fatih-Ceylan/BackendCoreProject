using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerType.GetAll
{
    public class GetAllCustomerTypeHandler : IRequestHandler<GetAllCustomerTypeRequest, GetAllCustomerTypeResponse>
    {
        readonly ICustomerTypeReadRepository _customerTypeReadRepository;
        public GetAllCustomerTypeHandler(ICustomerTypeReadRepository customerTypeReadRepository)
        {
            _customerTypeReadRepository = customerTypeReadRepository;
        }

        public Task<GetAllCustomerTypeResponse> Handle(GetAllCustomerTypeRequest request, CancellationToken cancellationToken)
        {
            var query = _customerTypeReadRepository
                                    .GetAllDeletedStatusDesc(false)
                                    .Select(ct => new CustomerTypeVM
                                    {
                                        Id = ct.Id.ToString(),
                                        Name = ct.Name
                                    });

            var totalCount = query.Count();
            var customerTypes = query.Skip(request.Page * request.Size)
                             .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerTypeResponse
            {
                TotalCount = totalCount,
                CustomerTypes = customerTypes,
            });
        }
    }
}

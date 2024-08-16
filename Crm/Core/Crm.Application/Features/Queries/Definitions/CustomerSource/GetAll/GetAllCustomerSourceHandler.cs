using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSource.GetAll
{
    public class GetAllCustomerSourceHandler : IRequestHandler<GetAllCustomerSourceRequest, GetAllCustomerSourceResponse>
    {
        readonly ICustomerSourceReadRepository _customerSourceReadRepository;

        public GetAllCustomerSourceHandler(ICustomerSourceReadRepository customerSourceReadRepository)
        {
            _customerSourceReadRepository = customerSourceReadRepository;
        }

        public Task<GetAllCustomerSourceResponse> Handle(GetAllCustomerSourceRequest request, CancellationToken cancellationToken)
        {
            var query = _customerSourceReadRepository
                                    .GetAllDeletedStatusDesc(false)
                                    .Select(cs => new CustomerSourceVM
                                    {
                                        Id = cs.Id.ToString(),
                                        Name = cs.Name,
                                    });

            var totalCount = query.Count();
            var customerSources = query.Skip(request.Page * request.Size)
                             .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerSourceResponse
            {
                TotalCount = totalCount,
                CustomerSources = customerSources,
            });
        }
    }
}

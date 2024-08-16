using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerRepresentative.GetAll
{
    public class GetAllCustomerRepresentativeHandler : IRequestHandler<GetAllCustomerRepresentativeRequest, GetAllCustomerRepresentativeResponse>
    {

        readonly ICustomerRepresentativeReadRepository _customerRepresentativeReadRepository;
        public GetAllCustomerRepresentativeHandler(ICustomerRepresentativeReadRepository customerRepresentativeReadRepository)
        {
            _customerRepresentativeReadRepository = customerRepresentativeReadRepository;
        }

        public Task<GetAllCustomerRepresentativeResponse> Handle(GetAllCustomerRepresentativeRequest request, CancellationToken cancellationToken)
        {
            var query = _customerRepresentativeReadRepository
            .GetAllDeletedStatusDesc(false)
                        .Select(ck => new CustomerRepresentativeVM
                        {
                            Id = ck.Id.ToString(),
                            Name = ck.Name
                        });

            var totalCount = query.Count();
            var customerRepresentatives = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerRepresentativeResponse
            {
                TotalCount = totalCount,
                CustomerRepresentatives = customerRepresentatives,
            });
        }
    }
}

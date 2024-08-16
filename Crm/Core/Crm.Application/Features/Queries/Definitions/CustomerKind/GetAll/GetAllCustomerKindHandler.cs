using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerKind.GetAll
{
    public class GetAllCustomerKindHandler : IRequestHandler<GetAllCustomerKindRequest, GetAllCustomerKindResponse>
    {
        readonly ICustomerKindReadRepository _customerKindReadRepository;

        public GetAllCustomerKindHandler(ICustomerKindReadRepository customerKindReadRepository)
        {
            _customerKindReadRepository = customerKindReadRepository;
        }

        public Task<GetAllCustomerKindResponse> Handle(GetAllCustomerKindRequest request, CancellationToken cancellationToken)
        {
            var query = _customerKindReadRepository
                        .GetAllDeletedStatusDesc(false)
                        .Select(ck => new CustomerKindVM
                        {
                            Id = ck.Id.ToString(),
                            Name = ck.Name
                        });

            var totalCount = query.Count();
            var customerKinds = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerKindResponse
            {
                TotalCount = totalCount,
                CustomerKinds = customerKinds,
            });
        }
    }
}

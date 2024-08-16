using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerKind.GetById
{
    public class GetByIdCustomerKindHandler : IRequestHandler<GetByIdCustomerKindRequest, GetByIdCustomerKindResponse>
    {
        readonly ICustomerKindReadRepository _customerKindReadRepository;

        public GetByIdCustomerKindHandler(ICustomerKindReadRepository customerKindReadRepository)
        {
            _customerKindReadRepository = customerKindReadRepository;
        }

        public async Task<GetByIdCustomerKindResponse> Handle(GetByIdCustomerKindRequest request, CancellationToken cancellationToken)
        {
            var customerKind = _customerKindReadRepository
                          .GetWhere(ck => ck.Id == Guid.Parse(request.Id), false)
                          .Select(ck => new CustomerKindVM
                          {
                              Id = ck.Id.ToString(),
                              Name = ck.Name
                          }).FirstOrDefault();

            return new()
            {
                CustomerKind = customerKind
            };
        }
    }
}

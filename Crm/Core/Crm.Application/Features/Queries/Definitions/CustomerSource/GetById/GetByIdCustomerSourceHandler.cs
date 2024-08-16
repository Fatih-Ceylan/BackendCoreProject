using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSource.GetById
{
    public class GetByIdCustomerSourceHandler : IRequestHandler<GetByIdCustomerSourceRequest, GetByIdCustomerSourceResponse>
    {
        readonly ICustomerSourceReadRepository _customerSourceReadRepository;

        public GetByIdCustomerSourceHandler(ICustomerSourceReadRepository customerSourceReadRepository)
        {
            _customerSourceReadRepository = customerSourceReadRepository;
        }

        public async Task<GetByIdCustomerSourceResponse> Handle(GetByIdCustomerSourceRequest request, CancellationToken cancellationToken)
        {
            var customerSource = _customerSourceReadRepository
                           .GetWhere(cs => cs.Id == Guid.Parse(request.Id), false)
                           .Select(cs => new CustomerSourceVM
                           {
                               Id = cs.Id.ToString(),
                               Name = cs.Name,
                           }).FirstOrDefault();

            return new()
            {
                CustomerSourceVM = customerSource
            };
        }
    }
}

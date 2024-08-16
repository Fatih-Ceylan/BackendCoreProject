using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerType.GetById
{
    public class GetByIdCustomerTypeHandler : IRequestHandler<GetByIdCustomerTypeRequest, GetByIdCustomerTypeResponse>
    {
        readonly ICustomerTypeReadRepository _customerTypeReadRepository;
        public GetByIdCustomerTypeHandler(ICustomerTypeReadRepository customerTypeReadRepository)
        {
            _customerTypeReadRepository = customerTypeReadRepository;
        }
        public async Task<GetByIdCustomerTypeResponse> Handle(GetByIdCustomerTypeRequest request, CancellationToken cancellationToken)
        {
            var customerType = _customerTypeReadRepository
                        .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                        .Select(ct => new CustomerTypeVM
                        {
                            Id = ct.Id.ToString(),
                            Name = ct.Name
                        }).FirstOrDefault();

            return new()
            {
                CustomerType = customerType
            };
        }
    }
}

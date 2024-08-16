using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerRepresentative.GetById
{
    public class GetByIdCustomerRepresentativeHandler : IRequestHandler<GetByIdCustomerRepresentativeRequest, GetByIdCustomerRepresentativeResponse>
    {

        readonly ICustomerRepresentativeReadRepository _customerRepresentativeReadRepository;

        public GetByIdCustomerRepresentativeHandler(ICustomerRepresentativeReadRepository customerRepresentativeReadRepository)
        {
            _customerRepresentativeReadRepository = customerRepresentativeReadRepository;
        }

        public  async Task<GetByIdCustomerRepresentativeResponse> Handle(GetByIdCustomerRepresentativeRequest request, CancellationToken cancellationToken)
        {
            var customerRepresentative = _customerRepresentativeReadRepository
                        .GetWhere(ck => ck.Id == Guid.Parse(request.Id), false)
                        .Select(ck => new CustomerRepresentativeVM
                        {
                            Id = ck.Id.ToString(),
                            Name = ck.Name
                        }).FirstOrDefault();

            return new()
            {
                CustomerRepresentatives = customerRepresentative
            };
        }
    }
}

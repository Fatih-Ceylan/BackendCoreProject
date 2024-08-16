using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerCategory.GetById
{
    public class GetByIdCustomerCategoryHandler : IRequestHandler<GetByIdCustomerCategoryRequest, GetByIdCustomerCategoryResponse>
    {
        readonly ICustomerCategoryReadRepository _customerCategoryReadRepository;
        public GetByIdCustomerCategoryHandler(ICustomerCategoryReadRepository customerCategoryReadRepository)
        {
            _customerCategoryReadRepository = customerCategoryReadRepository;
        }
        public async Task<GetByIdCustomerCategoryResponse> Handle(GetByIdCustomerCategoryRequest request, CancellationToken cancellationToken)
        {
            var customerCategory = _customerCategoryReadRepository
                                    .GetWhere(cc => cc.Id == Guid.Parse(request.Id), false)
                                    .Select(cc => new CustomerCategoryVM
                                    {
                                        Id = cc.Id.ToString(),
                                        Name = cc.Name
                                        
                                    }).FirstOrDefault();

            return new()
            {
                CustomerCategory = customerCategory
            };

        }
    }
}

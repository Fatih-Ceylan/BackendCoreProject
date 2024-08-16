using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerCategory.GetAll
{
    public class GetAllCustomerCategoryHandler : IRequestHandler<GetAllCustomerCategoryRequest, GetAllCustomerCategoryResponse>
    {
        readonly ICustomerCategoryReadRepository _customerCategoryReadRepository;
        public GetAllCustomerCategoryHandler(ICustomerCategoryReadRepository customerCategoryReadRepository)
        {
            _customerCategoryReadRepository = customerCategoryReadRepository;
        }
        public Task<GetAllCustomerCategoryResponse> Handle(GetAllCustomerCategoryRequest request, CancellationToken cancellationToken)
        {
            var query = _customerCategoryReadRepository
                                    .GetAllDeletedStatusDesc(false)
                                    .Select(cc => new CustomerCategoryVM
                                    {
                                        Id = cc.Id.ToString(),
                                        Name = cc.Name
                                      
                                    });

            var totalCount = query.Count();
            var customerCategories = query.Skip(request.Page * request.Size)
                             .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerCategoryResponse
            {
                TotalCount = totalCount,
                CustomerCategories = customerCategories,
            });
        }
    }
}

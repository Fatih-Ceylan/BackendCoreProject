using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductCategory.GetAll
{
    public class GetAllProductCategoryHandler : IRequestHandler<GetAllProductCategoryRequest, GetAllProductCategoryResponse>
    {
        readonly IProductCategoryReadRepository  _productCategoryReadRepository;

        public GetAllProductCategoryHandler(IProductCategoryReadRepository productCategoryReadRepository)
        {
            _productCategoryReadRepository = productCategoryReadRepository;
        }

        public Task<GetAllProductCategoryResponse> Handle(GetAllProductCategoryRequest request, CancellationToken cancellationToken)
        {
            var query = _productCategoryReadRepository.GetAllDeletedStatusDesc(false)
        .Select(or => new ProductCategoryVM
        {
            Id = or.Id.ToString(),
            ProductCategoryName = or.ProductCategoryName,


        });

            var totalCount = query.Count();
            var productCategories = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProductCategoryResponse
            {
                TotalCount = totalCount,
                productCategories = productCategories,
            });
        }
    }
}

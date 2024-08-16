using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductCategory.GetById
{
    public class GetByIdProductCategoryHandler : IRequestHandler<GetByIdProductCategoryRequest, GetByIdProductCategoryResponse>
    {
        readonly IProductCategoryReadRepository  _productCategoryReadRepository;

        public GetByIdProductCategoryHandler(IProductCategoryReadRepository productCategoryReadRepository)
        {
            _productCategoryReadRepository = productCategoryReadRepository;
        }

        public async  Task<GetByIdProductCategoryResponse> Handle(GetByIdProductCategoryRequest request, CancellationToken cancellationToken)
        {
            var productcategory = _productCategoryReadRepository
                    .GetWhere(pc => pc.Id == Guid.Parse(request.Id), false)
                    .Select(pc => new ProductCategoryVM
                    {
                        Id = pc.Id.ToString(),
                        ProductCategoryName = pc.ProductCategoryName

                    }).FirstOrDefault();

            return new()
            {
                productCategory = productcategory
            };
        }
    }
}

using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductSubCategory.GetById
{
    public class GetByIdProductSubCategoryHandler : IRequestHandler<GetByIdProductSubCategoryRequest, GetByIdProductSubCategoryResponse>
    {
        readonly IProductSubCategoryReadRepository  _productSubCategoryReadRepository;

        public GetByIdProductSubCategoryHandler(IProductSubCategoryReadRepository productSubCategoryReadRepository)
        {
            _productSubCategoryReadRepository = productSubCategoryReadRepository;
        }

        public async  Task<GetByIdProductSubCategoryResponse> Handle(GetByIdProductSubCategoryRequest request, CancellationToken cancellationToken)
        {
            var productsubcategory = _productSubCategoryReadRepository
                     .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                     .Select(ct => new ProductSubCategoryVM
                     {
                         Id = ct.Id.ToString(),
                         Name = ct.Name

                     }).FirstOrDefault();

            return new()
            {
                productSubCategory = productsubcategory
            };
        }
    }
}

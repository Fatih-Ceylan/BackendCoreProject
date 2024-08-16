using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductSubCategory.GetAll
{
    public class GetAllProductSubCategoryHandler : IRequestHandler<GetAllProductSubCategoryRequest, GetAllProductSubCategoryResponse>
    {
        readonly IProductSubCategoryReadRepository  _productSubCategoryReadRepository;

        public GetAllProductSubCategoryHandler(IProductSubCategoryReadRepository productSubCategoryReadRepository)
        {
            _productSubCategoryReadRepository = productSubCategoryReadRepository;
        }

        public Task<GetAllProductSubCategoryResponse> Handle(GetAllProductSubCategoryRequest request, CancellationToken cancellationToken)
        {
            var query = _productSubCategoryReadRepository.GetAllDeletedStatusDesc(false)
        .Select(or => new ProductSubCategoryVM
        {
            Id = or.Id.ToString(),
            Name = or.Name,


        });

            var totalCount = query.Count();
            var productsubcategory = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProductSubCategoryResponse
            {
                TotalCount = totalCount,
                productSubCategories = productsubcategory,
            });
        }
    }
}

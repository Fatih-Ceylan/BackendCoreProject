using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductMainCategory.GetAll
{
    public class GetAllProductMainCategoryHandler : IRequestHandler<GetAllProductMainCategoryRequest, GetAllProductMainCategoryResponse>
    {
        readonly IProductMainCategoryReadRepository  _productMainCategoryReadRepository;

        public GetAllProductMainCategoryHandler(IProductMainCategoryReadRepository productMainCategoryReadRepository)
        {
            _productMainCategoryReadRepository = productMainCategoryReadRepository;
        }

        public Task<GetAllProductMainCategoryResponse> Handle(GetAllProductMainCategoryRequest request, CancellationToken cancellationToken)
        {
            var query = _productMainCategoryReadRepository.GetAllDeletedStatusDesc(false)
         .Select(or => new ProductMainCategoryVM
         {
             Id = or.Id.ToString(),
             Name = or.Name,


         });

            var totalCount = query.Count();
            var productMainCategories = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProductMainCategoryResponse
            {
                TotalCount = totalCount,
                productMainCategories = productMainCategories,
            });
        }
    }
}

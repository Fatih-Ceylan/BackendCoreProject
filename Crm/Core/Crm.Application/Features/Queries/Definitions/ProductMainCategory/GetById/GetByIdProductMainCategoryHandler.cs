using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductMainCategory.GetById
{
    public class GetByIdProductMainCategoryHandler : IRequestHandler<GetByIdProductMainCategoryRequest, GetByIdProductMainCategoryResponse>
    {
        readonly IProductMainCategoryReadRepository  _productMainCategoryReadRepository;

        public GetByIdProductMainCategoryHandler(IProductMainCategoryReadRepository productMainCategoryReadRepository)
        {

            _productMainCategoryReadRepository= productMainCategoryReadRepository;
        }
        public async  Task<GetByIdProductMainCategoryResponse> Handle(GetByIdProductMainCategoryRequest request, CancellationToken cancellationToken)
        {
            var productmaincategory = _productMainCategoryReadRepository
                     .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                     .Select(ct => new ProductMainCategoryVM
                     {
                         Id = ct.Id.ToString(),
                         Name = ct.Name

                     }).FirstOrDefault();

            return new()
            {
                productMainCategory = productmaincategory
            };
        }
    }
}

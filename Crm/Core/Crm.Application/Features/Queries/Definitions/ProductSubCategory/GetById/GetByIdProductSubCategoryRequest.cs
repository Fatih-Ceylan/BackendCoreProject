using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductSubCategory.GetById
{
    public  class GetByIdProductSubCategoryRequest :IRequest<GetByIdProductSubCategoryResponse>
    {
        public string Id { get; set; }
    }
}

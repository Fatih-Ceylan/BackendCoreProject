using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductCategory.GetById
{
    public  class GetByIdProductCategoryRequest :IRequest<GetByIdProductCategoryResponse>
    {
        public string Id { get; set; }
    }
}

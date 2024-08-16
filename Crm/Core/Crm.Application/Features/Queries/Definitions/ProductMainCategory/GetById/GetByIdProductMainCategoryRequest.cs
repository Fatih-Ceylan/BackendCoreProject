using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductMainCategory.GetById
{
    public  class GetByIdProductMainCategoryRequest :IRequest<GetByIdProductMainCategoryResponse>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Delete
{
    public  class DeleteProductMainCategoryRequest :IRequest<DeleteProductMainCategoryResponse>
    {
        public string Id { get; set; }
    }
}

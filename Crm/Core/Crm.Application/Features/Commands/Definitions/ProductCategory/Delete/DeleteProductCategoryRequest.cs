using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductCategory.Delete
{
    public  class DeleteProductCategoryRequest :IRequest<DeleteProductCategoryResponse>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Delete
{
    public  class DeleteProductSubCategoryRequest :IRequest<DeleteProductSubCategoryResponse>
    {
        public string Id { get; set; }
    }
}

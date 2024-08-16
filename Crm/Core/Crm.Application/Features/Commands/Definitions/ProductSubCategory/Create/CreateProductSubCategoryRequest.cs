using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Create
{
    public  class CreateProductSubCategoryRequest :IRequest<CreateProductSubCategoryResponse>
    {
        public string Name { get; set; }
    }
}

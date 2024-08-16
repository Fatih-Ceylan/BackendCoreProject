using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductCategory.Create
{
    public  class CreateProductCategoryRequest :IRequest<CreateProductCategoryResponse>
    {
        public string Name { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Create
{
    public  class CreateProductMainCategoryRequest :IRequest<CreateProductMainCategoryResponse>
    {
        public string Name { get; set; }
    }
}

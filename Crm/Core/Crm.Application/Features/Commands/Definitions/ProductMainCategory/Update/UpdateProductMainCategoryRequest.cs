using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Update
{
    public  class UpdateProductMainCategoryRequest :IRequest<UpdateProductMainCategoryResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

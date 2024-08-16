using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Update
{
    public  class UpdateProductSubCategoryRequest :IRequest<UpdateProductSubCategoryResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

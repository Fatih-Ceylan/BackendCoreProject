using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductCategory.Update
{
    public  class UpdateProductCategoryRequest : IRequest<UpdateProductCategoryResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

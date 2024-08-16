using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Product.Update
{
    public  class UpdateProductRequest :IRequest<UpdateProductResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

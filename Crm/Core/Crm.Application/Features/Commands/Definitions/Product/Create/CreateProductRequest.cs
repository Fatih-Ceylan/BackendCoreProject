using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Product.Create
{
    public  class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
    }
}

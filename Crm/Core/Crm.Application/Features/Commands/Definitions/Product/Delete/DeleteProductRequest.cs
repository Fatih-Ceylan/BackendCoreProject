using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Product.Delete
{
    public class DeleteProductRequest :IRequest<DeleteProductResponse>
    {
        public string Id { get; set; }
    }
}

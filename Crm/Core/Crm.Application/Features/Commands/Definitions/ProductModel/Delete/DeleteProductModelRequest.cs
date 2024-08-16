using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductModel.Delete
{
    public  class DeleteProductModelRequest :IRequest<DeleteProductModelResponse>
    {
        public string Id { get; set; }
    }
}

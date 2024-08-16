using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Delete
{
    public  class DeleteProductManufacturerRequest :IRequest<DeleteProductManufacturerResponse>
    {
        public string Id { get; set; }
    }
}

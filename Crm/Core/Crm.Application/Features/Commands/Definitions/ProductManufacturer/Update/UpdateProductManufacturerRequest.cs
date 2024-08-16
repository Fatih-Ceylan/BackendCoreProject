using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Update
{
    public  class UpdateProductManufacturerRequest :IRequest<UpdateProductManufacturerResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

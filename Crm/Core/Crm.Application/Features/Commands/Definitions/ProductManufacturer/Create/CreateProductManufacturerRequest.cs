using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Create
{
    public   class CreateProductManufacturerRequest :IRequest<CreateProductManufacturerResponse>
    {
        public string Name { get; set; }
    }
}

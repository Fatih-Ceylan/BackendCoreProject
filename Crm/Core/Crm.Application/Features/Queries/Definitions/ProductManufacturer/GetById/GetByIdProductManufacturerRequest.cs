using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductManufacturer.GetById
{
    public  class GetByIdProductManufacturerRequest :IRequest<GetByIdProductManufacturerResponse>
    {
        public string Id { get; set; }
    }
}

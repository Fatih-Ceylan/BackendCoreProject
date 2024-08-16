using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductManufacturer.GetById
{
    public class GetByIdProductManufacturerHandler : IRequestHandler<GetByIdProductManufacturerRequest, GetByIdProductManufacturerResponse>
    {
        readonly IProductManufacturerReadRepository  _productManufacturerReadRepository;

        public GetByIdProductManufacturerHandler(IProductManufacturerReadRepository productManufacturerReadRepository)
        {
            _productManufacturerReadRepository= productManufacturerReadRepository;
        }

        public async  Task<GetByIdProductManufacturerResponse> Handle(GetByIdProductManufacturerRequest request, CancellationToken cancellationToken)
        {
            var productManufacturer = _productManufacturerReadRepository
                    .GetWhere(pm => pm.Id == Guid.Parse(request.Id), false)
                    .Select(pm => new ProductManufacturerVM
                    {
                        Id = pm.Id.ToString(),
                        ProductManufacturerName = pm.ProductManufacturerName

                    }).FirstOrDefault();

            return new()
            {
                productManufacturer = productManufacturer
            };
        }
    }
}

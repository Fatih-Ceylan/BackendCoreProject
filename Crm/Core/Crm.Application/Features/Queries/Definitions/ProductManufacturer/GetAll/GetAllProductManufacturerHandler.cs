using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductManufacturer.GetAll
{
    public class GetAllProductManufacturerHandler : IRequestHandler<GetAllProductManufacturerRequest, GetAllProductManufacturerResponse>
    {
        readonly IProductManufacturerReadRepository  _productManufacturerReadRepository;

        public GetAllProductManufacturerHandler(IProductManufacturerReadRepository productManufacturerReadRepository)
        {
            _productManufacturerReadRepository = productManufacturerReadRepository;
        }

        public Task<GetAllProductManufacturerResponse> Handle(GetAllProductManufacturerRequest request, CancellationToken cancellationToken)
        {
            var query = _productManufacturerReadRepository.GetAllDeletedStatusDesc(false)
         .Select(or => new ProductManufacturerVM
         {
             Id = or.Id.ToString(),
             ProductManufacturerName = or.ProductManufacturerName,

         });

            var totalCount = query.Count();
            var productManufacturers = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProductManufacturerResponse
            {
                TotalCount = totalCount,
                productManufacturers = productManufacturers,
            });
        }
    }
}

using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductBrand.GetAll
{
    public class GetAllProductBrandHandler : IRequestHandler<GetAllProductBrandRequest, GetAllProductBrandResponse>
    {
        readonly IProductBrandReadRepository  _productBrandReadRepository;

        public GetAllProductBrandHandler(IProductBrandReadRepository productBrandReadRepository)
        {
            _productBrandReadRepository = productBrandReadRepository;
        }

        public  Task<GetAllProductBrandResponse> Handle(GetAllProductBrandRequest request, CancellationToken cancellationToken)
        {
            var query = _productBrandReadRepository.GetAllDeletedStatusDesc(false)
        .Select(or => new ProductBrandVM
        {
            Id = or.Id.ToString(),
            ProductBrandName = or.ProductBrandName,


        });

            var totalCount = query.Count();
            var productBrands = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProductBrandResponse
            {
                TotalCount = totalCount,
                ProductBrands = productBrands
            });
        }
    }
}

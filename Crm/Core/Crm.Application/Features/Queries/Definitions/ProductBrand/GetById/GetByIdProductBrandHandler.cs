using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductBrand.GetById
{
    public class GetByIdProductBrandHandler : IRequestHandler<GetByIdProductBrandRequest, GetByIdProductBrandResponse>
    {
        readonly IProductBrandReadRepository  _productBrandReadRepository;

        public GetByIdProductBrandHandler(IProductBrandReadRepository productBrandReadRepository)
        {
            _productBrandReadRepository= productBrandReadRepository;
        }
        public async  Task<GetByIdProductBrandResponse> Handle(GetByIdProductBrandRequest request, CancellationToken cancellationToken)
        {
            var productBrand = _productBrandReadRepository
                     .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                     .Select(ct => new ProductBrandVM
                     {
                         Id = ct.Id.ToString(),
                         ProductBrandName = ct.ProductBrandName
                         

                     }).FirstOrDefault();

            return new()
            {
                productBrand = productBrand
            };
        }
    }
}

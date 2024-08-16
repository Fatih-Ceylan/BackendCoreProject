using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Product.GetById
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, GetByIdProductResponse>
    {
        readonly IProductReadRepository  _productReadRepository;

        public GetByIdProductHandler(IProductReadRepository productReadRepository)
        {

            _productReadRepository = productReadRepository;
        }
        public async  Task<GetByIdProductResponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var product = _productReadRepository
                     .GetWhere(p => p.Id == Guid.Parse(request.Id), false)
                     .Select(p => new ProductVM
                     {
                         Id = p.Id.ToString(),
                         ProductName = p.ProductName
                     }).FirstOrDefault();

            return  new()
            {
                Product = product
            };
        }
    }
}

using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Product.GetAll
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
    {
        readonly IProductReadRepository  _productReadRepository;

        public GetAllProductHandler(IProductReadRepository productReadRepository)
        {

            _productReadRepository = productReadRepository;
        }
        public Task<GetAllProductResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var query = _productReadRepository.GetAllDeletedStatusDesc(false)
        .Select(p => new ProductVM
        {
            Id = p.Id.ToString(),
            ProductName = p.ProductName,


        });

            var totalCount = query.Count();
            var Products = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProductResponse
            {
                TotalCount = totalCount,
                Products = Products,
            });
        }
    }
}

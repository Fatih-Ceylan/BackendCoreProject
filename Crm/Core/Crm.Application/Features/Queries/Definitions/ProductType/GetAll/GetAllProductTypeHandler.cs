using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductType.GetAll
{
    public class GetAllProductTypeHandler : IRequestHandler<GetAllProductTypeRequest, GetAllProductTypeResponse>
    {
        readonly IProductTypeReadRepository  _productTypeReadRepository;

        public GetAllProductTypeHandler(IProductTypeReadRepository productTypeReadRepository)
        {
            _productTypeReadRepository = productTypeReadRepository;
        }

        public Task<GetAllProductTypeResponse> Handle(GetAllProductTypeRequest request, CancellationToken cancellationToken)
        {
            var query = _productTypeReadRepository.GetAllDeletedStatusDesc(false)
        .Select(or => new ProductTypeVM
        {
            Id = or.Id.ToString(),
            Name = or.Name,


        });

            var totalCount = query.Count();
            var productTypes = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProductTypeResponse
            {
                TotalCount = totalCount,
                productTypes = productTypes,
            });
        }
    }
}

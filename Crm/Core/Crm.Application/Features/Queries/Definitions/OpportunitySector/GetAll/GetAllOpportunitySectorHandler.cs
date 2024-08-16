using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunitySector.GetAll
{
    public class GetAllOpportunitySectorHandler : IRequestHandler<GetAllOpportunitySectorRequest, GetAllOpportunitySectorResponse>
    {
        readonly IOpportunitySectorReadRepository  _opportunitySectorReadRepository;

        public GetAllOpportunitySectorHandler(IOpportunitySectorReadRepository opportunitySectorReadRepository)
        {
            _opportunitySectorReadRepository = opportunitySectorReadRepository;
        }

        public  Task<GetAllOpportunitySectorResponse> Handle(GetAllOpportunitySectorRequest request, CancellationToken cancellationToken)
        {
            var query = _opportunitySectorReadRepository.GetAllDeletedStatusDesc(false)
           .Select(or => new OpportunitySectorVM
           {
               Id = or.Id.ToString(),
               Name = or.Name,


           });
            var totalCount = query.Count();

          
            var Opportunitysectors =  request.DoPagination ? query.Skip(request.Page * request.Size)
                                                  .Take(request.Size).ToList()
                                                  : query.ToList();

            return Task.FromResult(new GetAllOpportunitySectorResponse
            {
                TotalCount = totalCount,
                OpportunitySectors = Opportunitysectors,
            });
        }
    }
}

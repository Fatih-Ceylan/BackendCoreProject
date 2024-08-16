using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunitySector.GetById
{
    public class GetByIdOpportunitySectorHandler : IRequestHandler<GetByIdOpportunitySectorRequest, GetByIdOpportunitySectorResponse>
    {
        readonly IOpportunitySectorReadRepository  _opportunitySectorReadRepository;

        public GetByIdOpportunitySectorHandler(IOpportunitySectorReadRepository opportunitySectorReadRepository)
        {
            _opportunitySectorReadRepository = opportunitySectorReadRepository;
        }

        public async Task<GetByIdOpportunitySectorResponse> Handle(GetByIdOpportunitySectorRequest request, CancellationToken cancellationToken)
        {
            var opportunitysectors = _opportunitySectorReadRepository
                      .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                      .Select(ct => new OpportunitySectorVM
                      {
                          Id = ct.Id.ToString(),
                          Name = ct.Name

                      }).FirstOrDefault();

            return new()
            {
                OpportunitySector = opportunitysectors
            };
        }
    }
}

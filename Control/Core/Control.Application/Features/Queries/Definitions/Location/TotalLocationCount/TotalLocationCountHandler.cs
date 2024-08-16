using GControl.Application.Repositories.ReadRepository;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Location.TotalLocationCount
{
    public class TotalLocationCountHandler : IRequestHandler<TotalLocationCountRequest, TotalLocationCountResponse>
    {
        readonly ILocationReadRepository _totalLocationCountReadRepository;

        public TotalLocationCountHandler(ILocationReadRepository totalLocationCountReadRepository)
        {
            _totalLocationCountReadRepository = totalLocationCountReadRepository;
        }

        public Task<TotalLocationCountResponse> Handle(TotalLocationCountRequest request, CancellationToken cancellationToken)
        {
            var query = _totalLocationCountReadRepository
                        .GetAllDeletedStatusDesc(false);

            var totalLocationCount = query.Count();
            return Task.FromResult(new TotalLocationCountResponse
            {
                TotalLocationCount = totalLocationCount
            });
        }
    }
}

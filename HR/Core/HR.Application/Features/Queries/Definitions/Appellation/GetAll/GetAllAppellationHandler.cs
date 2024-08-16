using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.Appellation.GetAll
{
    public class GetAllAppellationHandler : IRequestHandler<GetAllAppellationRequest, GetAllAppellationResponse>
    {
        public IAppellationReadRepository _appellationReadRepository;
        public GetAllAppellationHandler(IAppellationReadRepository appellationReadRepository)
        {
            _appellationReadRepository = appellationReadRepository;
        }

        public Task<GetAllAppellationResponse> Handle(GetAllAppellationRequest request, CancellationToken cancellationToken)
        {
            var query = _appellationReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
                .Select(c => new AppellationVM
                {
                    Id = c.Id.ToString(),
                    Code = c.Code,
                    Name = c.Name,
                    MainAppellationId = c.MainAppellationId.ToString(),
                    CreatedDate = c.CreatedDate,
                });
            var totalCount = query.Count();
            var appellations = request.DoPagination ? query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList() : query.ToList();

            return Task.FromResult(new GetAllAppellationResponse
            {
                TotalCount = totalCount,
                Appellations = appellations,
            });
        }
    }
}

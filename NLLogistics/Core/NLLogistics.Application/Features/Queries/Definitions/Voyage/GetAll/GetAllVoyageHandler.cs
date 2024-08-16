using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Voyage;

namespace NLLogistics.Application.Features.Queries.Definitions.Voyage.GetAll
{
    public class GetAllVoyageHandler : IRequestHandler<GetAllVoyageRequest, GetAllVoyageResponse>
    {
        readonly IVoyageReadRepository _voyageReadRepository;

        public GetAllVoyageHandler(IVoyageReadRepository voyageReadRepository)
        {
            _voyageReadRepository = voyageReadRepository;
        }

        public async Task<GetAllVoyageResponse> Handle(GetAllVoyageRequest request, CancellationToken cancellationToken)
        {
            var query = _voyageReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
                                              .Select(v => new VoyageVM
                                              {
                                                  Id = v.Id.ToString(),
                                                  CreatedDate = v.CreatedDate,
                                                  VesselId = v.VesselId.ToString(),
                                                  VesselName = v.Vessel.Name,
                                                  Name = v.Name,
                                                  VesselVoyage = v.Vessel.Name + " / " + v.Name
                                              });
            var totalCount = query.Count();
            var voyages = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                       .Take(request.Size)
                                                       .ToList()
                                                : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Voyages = voyages
            };
        }
    }
}
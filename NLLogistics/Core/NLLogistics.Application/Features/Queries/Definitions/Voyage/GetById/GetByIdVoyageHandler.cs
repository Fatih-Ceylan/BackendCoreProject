using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Voyage;

namespace NLLogistics.Application.Features.Queries.Definitions.Voyage.GetById
{
    public class GetByIdVoyageHandler : IRequestHandler<GetByIdVoyageRequest, GetByIdVoyageResponse>
    {
        readonly IVoyageReadRepository _voyageReadRepository;

        public GetByIdVoyageHandler(IVoyageReadRepository voyageReadRepository)
        {
            _voyageReadRepository = voyageReadRepository;
        }

        public async Task<GetByIdVoyageResponse> Handle(GetByIdVoyageRequest request, CancellationToken cancellationToken)
        {
            var voyage = _voyageReadRepository.GetWhere(x => x.Id == Guid.Parse(request.Id))
                                                .Select(v => new VoyageVM
                                                {
                                                    Id = v.Id.ToString(),
                                                    CreatedDate = v.CreatedDate,
                                                    VesselId = v.VesselId.ToString(),
                                                    VesselName = v.Vessel.Name,
                                                    Name = v.Name,
                                                    VesselVoyage = v.Vessel.Name + " / " + v.Name
                                                }).FirstOrDefault();
            return new()
            {
                Voyage = voyage
            };
        }
    }
}
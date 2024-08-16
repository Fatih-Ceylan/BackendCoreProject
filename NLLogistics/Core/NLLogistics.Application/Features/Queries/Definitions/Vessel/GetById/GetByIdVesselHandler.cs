using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Vessel;

namespace NLLogistics.Application.Features.Queries.Definitions.Vessel.GetById
{
    public class GetByIdVesselHandler : IRequestHandler<GetByIdVesselRequest, GetByIdVesselResponse>
    {
        readonly IVesselReadRepository _vesselReadRepository;

        public GetByIdVesselHandler(IVesselReadRepository vesselReadRepository)
        {
            _vesselReadRepository = vesselReadRepository;
        }

        public async Task<GetByIdVesselResponse> Handle(GetByIdVesselRequest request, CancellationToken cancellationToken)
        {
            var vessel = _vesselReadRepository.GetWhere(x => x.Id == Guid.Parse(request.Id))
                                                .Select(v => new VesselVM
                                                {
                                                    Id = v.Id.ToString(),
                                                    CreatedDate = v.CreatedDate,
                                                    Name = v.Name,
                                                    CountryId = v.CountryId,
                                                    CountryName = v.Country.Name,
                                                    Year = v.Year,
                                                    Imo = v.Imo,
                                                    Link = v.Link,
                                                }).FirstOrDefault();
            return new()
            {
                Vessel = vessel
            };
        }
    }
}
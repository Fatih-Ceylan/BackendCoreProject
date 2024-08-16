using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Vessel;

namespace NLLogistics.Application.Features.Queries.Definitions.Vessel.GetAll
{
    public class GetAllVesselHandler : IRequestHandler<GetAllVesselRequest, GetAllVesselResponse>
    {
        readonly IVesselReadRepository _vesselReadRepository;

        public GetAllVesselHandler(IVesselReadRepository vesselReadRepository)
        {
            _vesselReadRepository = vesselReadRepository;
        }

        public async Task<GetAllVesselResponse> Handle(GetAllVesselRequest request, CancellationToken cancellationToken)
        {
            var query = _vesselReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
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
                                              });
            var totalCount = query.Count();
            var vessels = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                       .Take(request.Size)
                                                       .ToList()
                                                : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Vessels = vessels
            };
        }
    }
}
using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Airport;

namespace NLLogistics.Application.Features.Queries.Definitions.Airport.GetAll
{
    public class GetAllAirportHandler : IRequestHandler<GetAllAirportRequest, GetAllAirportResponse>
    {
        readonly IAirportReadRepository _airportReadRepository;

        public GetAllAirportHandler(IAirportReadRepository airportReadRepository)
        {
            _airportReadRepository = airportReadRepository;
        }

        public async Task<GetAllAirportResponse> Handle(GetAllAirportRequest request, CancellationToken cancellationToken)
        {
            var query = _airportReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
                                              .Select(a => new AirportVM
                                              {
                                                  Id = a.Id.ToString(),
                                                  CreatedDate = a.CreatedDate,
                                                  Code = a.Code,
                                                  Name = a.Name,
                                                  CountryId = a.CountryId,
                                                  CountryName = a.Country != null ? a.Country.Name : null

                                              });
            var totalCount = query.Count();
            var airports = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                       .Take(request.Size)
                                                       .ToList()
                                                : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Airports = airports
            };
        }
    }
}
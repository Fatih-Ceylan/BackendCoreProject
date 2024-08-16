using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Airport;

namespace NLLogistics.Application.Features.Queries.Definitions.Airport.GetById
{
    public class GetByIdAirportHandler : IRequestHandler<GetByIdAirportRequest, GetByIdAirportResponse>
    {
        readonly IAirportReadRepository _airportReadRepository;

        public GetByIdAirportHandler(IAirportReadRepository airportReadRepository)
        {
            _airportReadRepository = airportReadRepository;
        }

        public async Task<GetByIdAirportResponse> Handle(GetByIdAirportRequest request, CancellationToken cancellationToken)
        {
            var airport = _airportReadRepository.GetWhere(x => x.Id == Guid.Parse(request.Id))
                                                .Select(a => new AirportVM
                                                {
                                                    Id = a.Id.ToString(),
                                                    CreatedDate = a.CreatedDate,
                                                    Code = a.Code,
                                                    Name = a.Name,
                                                    CountryId = a.CountryId,
                                                    CountryName = a.Country != null ? a.Country.Name : null

                                                }).FirstOrDefault();
            return new()
            {
                Airport = airport
            };
        }
    }
}
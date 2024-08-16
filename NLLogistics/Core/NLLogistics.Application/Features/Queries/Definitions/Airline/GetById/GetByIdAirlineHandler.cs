using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Airline;

namespace NLLogistics.Application.Features.Queries.Definitions.Airline.GetById
{
    public class GetByIdAirlineHandler : IRequestHandler<GetByIdAirportRequest, GetByIdAirlineResponse>
    {
        readonly IAirlineReadRepository _airlineReadRepository;

        public GetByIdAirlineHandler(IAirlineReadRepository airlineReadRepository)
        {
            _airlineReadRepository = airlineReadRepository;
        }

        public async Task<GetByIdAirlineResponse> Handle(GetByIdAirportRequest request, CancellationToken cancellationToken)
        {
            var airline = _airlineReadRepository.GetWhere(x => x.Id == Guid.Parse(request.Id))
                                                .Select(a => new AirlineVM
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
                Airline = airline
            };
        }
    }
}
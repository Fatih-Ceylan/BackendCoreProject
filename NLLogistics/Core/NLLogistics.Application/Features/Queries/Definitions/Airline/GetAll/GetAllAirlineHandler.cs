using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Airline;

namespace NLLogistics.Application.Features.Queries.Definitions.Airline.GetAll
{
    public class GetAllAirlineHandler : IRequestHandler<GetAllAirlineRequest, GetAllAirlineResponse>
    {
        readonly IAirlineReadRepository _airlineReadRepository;

        public GetAllAirlineHandler(IAirlineReadRepository airlineReadRepository)
        {
            _airlineReadRepository = airlineReadRepository;
        }

        public async Task<GetAllAirlineResponse> Handle(GetAllAirlineRequest request, CancellationToken cancellationToken)
        {
            var query = _airlineReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
                                              .Select(a => new AirlineVM
                                              {
                                                  Id = a.Id.ToString(),
                                                  CreatedDate = a.CreatedDate,
                                                  Code = a.Code,
                                                  Name = a.Name,
                                                  CountryId = a.CountryId,
                                                  CountryName = a.Country != null ? a.Country.Name : null
                                              });
            var totalCount = query.Count();
            var airlines = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                       .Take(request.Size)
                                                       .ToList()
                                                : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Airlines = airlines
            };
        }
    }
}
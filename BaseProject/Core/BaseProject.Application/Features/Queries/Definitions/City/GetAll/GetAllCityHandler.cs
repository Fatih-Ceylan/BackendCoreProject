using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.City;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.City.GetAll
{
    public class GetAllCityHandler : IRequestHandler<GetAllCityRequest, GetAllCityResponse>
    {
        readonly ICityReadRepository _cityReadRepository;

        public GetAllCityHandler(ICityReadRepository cityReadRepository)
        {
            _cityReadRepository = cityReadRepository;
        }

        public async Task<GetAllCityResponse> Handle(GetAllCityRequest request, CancellationToken cancellationToken)
        {
            var query = _cityReadRepository.GetAllDeletedStatus(false, request.IsDeleted)
                                              .Select(c => new CityVM
                                              {
                                                  Id = c.Idc,
                                                  CountryId = c.CountryId,
                                                  CountryName = c.Country.Name,
                                                  Name = c.Name,
                                              });
            if (request.CountryId != null)
            {
                query = query.Where(c => c.CountryId == request.CountryId);
            }

            var totalCount = query.Count();
            var cities = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                     .Take(request.Size)
                                                     .ToList()
                                              : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Cities = cities
            };
        }
    }
}
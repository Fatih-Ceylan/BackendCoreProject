using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.City;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.City.GetById
{
    public class GetByIdCityHandler : IRequestHandler<GetByIdCityRequest, GetByIdCityResponse>
    {
        readonly ICityReadRepository _cityReadRepository;

        public GetByIdCityHandler(ICityReadRepository cityReadRepository)
        {
            _cityReadRepository = cityReadRepository;
        }

        public async Task<GetByIdCityResponse> Handle(GetByIdCityRequest request, CancellationToken cancellationToken)
        {
            var city = _cityReadRepository.GetAll(false).Where(c => c.Idc == request.Id)
                                                .Select(c => new CityVM
                                                {
                                                    Id = c.Idc,
                                                    CountryId = c.CountryId,
                                                    CountryName = c.Country.Name,
                                                    Name = c.Name,
                                                }).FirstOrDefault();

            return new()
            {
                City = city
            };
        }
    }
}
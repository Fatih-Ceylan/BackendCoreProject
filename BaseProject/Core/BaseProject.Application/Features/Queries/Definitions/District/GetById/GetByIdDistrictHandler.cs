using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.District;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.District.GetById
{
    public class GetByIdDistrictHandler : IRequestHandler<GetByIdDistrictRequest, GetByIdDistrictResponse>
    {
        readonly IDistrictReadRepository _districtReadRepository;

        public GetByIdDistrictHandler(IDistrictReadRepository districtReadRepository)
        {
            _districtReadRepository = districtReadRepository;
        }

        public async Task<GetByIdDistrictResponse> Handle(GetByIdDistrictRequest request, CancellationToken cancellationToken)
        {
            var district = _districtReadRepository.GetAll(false).Where(c => c.Idc == request.Id)
                                                  .Select(d => new DistrictVM
                                                  {
                                                      Id = d.Idc,
                                                      CountryId = d.CountryId,
                                                      CountryName = d.City.Country.Name,
                                                      CityId = d.CityId,
                                                      CityName = d.City.Name,
                                                      Name = d.Name,
                                                  }).FirstOrDefault();

            return new()
            {
                District = district
            };
        }
    }
}
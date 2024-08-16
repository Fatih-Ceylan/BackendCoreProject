using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.District;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.District.GetAll
{
    public class GetAllDistrictHandler : IRequestHandler<GetAllDistrictRequest, GetAllDistrictResponse>
    {
        readonly IDistrictReadRepository _districtReadRepository;

        public GetAllDistrictHandler(IDistrictReadRepository districtReadRepository)
        {
            _districtReadRepository = districtReadRepository;
        }

        public async Task<GetAllDistrictResponse> Handle(GetAllDistrictRequest request, CancellationToken cancellationToken)
        {
            var query = _districtReadRepository.GetAllDeletedStatus(false, request.IsDeleted)
                                              .Select(d => new DistrictVM
                                              {
                                                  Id = d.Idc,
                                                  CountryId = d.CountryId,
                                                  CountryName = d.City.Country.Name,
                                                  CityId = d.CityId,
                                                  CityName = d.City.Name,
                                                  Name = d.Name,
                                              });
            if (request.CityId != null)
            {
                query = query.Where(d => d.CityId == request.CityId);
            }

            var totalCount = query.Count();
            var districts = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                        .Take(request.Size)
                                                        .ToList()
                                                 : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Districts = districts
            };
        }
    }
}
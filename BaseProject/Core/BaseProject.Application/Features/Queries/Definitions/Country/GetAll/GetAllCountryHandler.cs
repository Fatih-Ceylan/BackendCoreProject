using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.Country;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Country.GetAll
{
    public class GetAllCountryHandler : IRequestHandler<GetAllCountryRequest, GetAllCountryResponse>
    {
        readonly ICountryReadRepository _countryReadRepository;

        public GetAllCountryHandler(ICountryReadRepository countryReadRepository)
        {
            _countryReadRepository = countryReadRepository;
        }

        public async Task<GetAllCountryResponse> Handle(GetAllCountryRequest request, CancellationToken cancellationToken)
        {
            var query = _countryReadRepository.GetAllDeletedStatus(false, request.IsDeleted)
                                              .Select(c => new CountryVM
                                              {
                                                  Id = c.Idc,
                                                  Name = c.Name,
                                              });
            var totalCount = query.Count();
            var countries = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                        .Take(request.Size)
                                                        .ToList()
                                                 : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Countries = countries
            };
        }
    }
}
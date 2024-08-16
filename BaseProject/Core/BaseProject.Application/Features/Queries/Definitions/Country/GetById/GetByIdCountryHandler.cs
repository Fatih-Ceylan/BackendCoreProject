using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.Country;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Country.GetById
{
    public class GetByIdCountryHandler : IRequestHandler<GetByIdCountryRequest, GetByIdCountryResponse>
    {
        readonly ICountryReadRepository _countryReadRepository;

        public GetByIdCountryHandler(ICountryReadRepository countryReadRepository)
        {
            _countryReadRepository = countryReadRepository;
        }

        public async Task<GetByIdCountryResponse> Handle(GetByIdCountryRequest request, CancellationToken cancellationToken)
        {
            var country = _countryReadRepository.GetAll(false).Where(c => c.Idc == request.Id)
                                                .Select(c => new CountryVM
                                                {
                                                   Id = c.Idc,
                                                   Name = c.Name,
                                                }).FirstOrDefault();

            return new()
            {
                Country = country
            };
        }
    }
}
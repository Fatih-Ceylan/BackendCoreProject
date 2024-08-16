using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.Country.Create
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryRequest, CreateCountryResponse>
    {
        readonly ICountryWriteRepository _countryWriteRepository;

        public CreateCountryHandler(ICountryWriteRepository countryWriteRepository)
        {
            _countryWriteRepository = countryWriteRepository;
        }

        public async Task<CreateCountryResponse> Handle(CreateCountryRequest request, CancellationToken cancellationToken)
        {
            T.Country country = new();
            country.Name = request.Name;

            country = await _countryWriteRepository.AddAsync(country);
            await _countryWriteRepository.SaveAsync();

            return new()
            {
                Id = country.Idc,
                Name = country.Name,
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }
    }
}
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.Country.Update
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryRequest, UpdateCountryResponse>
    {
        readonly ICountryReadRepository _countryReadRepository;
        readonly ICountryWriteRepository _countryWriteRepository;

        public UpdateCountryHandler(ICountryReadRepository countryReadRepository, ICountryWriteRepository countryWriteRepository)
        {
            _countryReadRepository = countryReadRepository;
            _countryWriteRepository = countryWriteRepository;
        }

        public async Task<UpdateCountryResponse> Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
        {
            var country = _countryReadRepository.GetAll()
                                               .Where(c => c.Idc == request.Id).FirstOrDefault();
            if (country != null)
            {
                country.Name = request.Name;
                await _countryWriteRepository.SaveAsync();

                return new()
                {
                    Id = country.Idc,
                    Name = country.Name,
                    Message = CommandResponseMessage.UpdatedSuccess.ToString()
                };
            }
            else
            {
                throw new Exception("This country is not registered.");
            }

        }
    }
}
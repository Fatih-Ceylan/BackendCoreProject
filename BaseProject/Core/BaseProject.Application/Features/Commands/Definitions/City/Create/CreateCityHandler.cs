using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.City.Create
{
    public class CreateCityHandler : IRequestHandler<CreateCityRequest, CreateCityResponse>
    {
        readonly ICityWriteRepository _cityWriteRepository;

        public CreateCityHandler(ICityWriteRepository cityWriteRepository)
        {
            _cityWriteRepository = cityWriteRepository;
        }

        public async Task<CreateCityResponse> Handle(CreateCityRequest request, CancellationToken cancellationToken)
        {
            T.City city = new();
            city.Name = request.Name;
            city.CountryId = request.CountryId;

            city = await _cityWriteRepository.AddAsync(city);
            await _cityWriteRepository.SaveAsync();

            return new()
            {
                Id = city.Idc,
                CountryId = city.CountryId,
                Name = city.Name,
                Message = CommandResponseMessage.AddedSuccess.ToString(),
            };
        }
    }
}
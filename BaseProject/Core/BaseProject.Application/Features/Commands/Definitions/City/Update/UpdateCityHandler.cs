using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.City.Update
{
    public class UpdateCityHandler : IRequestHandler<UpdateCityRequest, UpdateCityResponse>
    {
        readonly ICityReadRepository _cityReadRepository;
        readonly ICityWriteRepository _cityWriteRepository;

        public UpdateCityHandler(ICityWriteRepository cityWriteRepository, ICityReadRepository cityReadRepository)
        {
            _cityWriteRepository = cityWriteRepository;
            _cityReadRepository = cityReadRepository;
        }

        public async Task<UpdateCityResponse> Handle(UpdateCityRequest request, CancellationToken cancellationToken)
        {
            var city = _cityReadRepository.GetAll().Where(c => c.Idc == request.Id).FirstOrDefault();

            if (city != null)
            {
                city.CountryId = request.CountryId;
                city.Name = request.Name;
                await _cityWriteRepository.SaveAsync();

                return new()
                {
                    Id = city.Idc,
                    CountryId = city.CountryId,
                    Name = city.Name,
                    Message = CommandResponseMessage.UpdatedSuccess.ToString(),
                };
            }
            else
                throw new Exception("This city is not registered.");
        }
    }
}
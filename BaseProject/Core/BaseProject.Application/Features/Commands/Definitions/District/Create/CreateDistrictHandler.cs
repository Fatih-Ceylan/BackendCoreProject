using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.District.Create
{
    public class CreateDistrictHandler : IRequestHandler<CreateDistrictRequest, CreateDistrictResponse>
    {
        readonly IDistrictWriteRepository _districtWriteRepository;

        public CreateDistrictHandler(IDistrictWriteRepository districtWriteRepository)
        {
            _districtWriteRepository = districtWriteRepository;
        }

        public async Task<CreateDistrictResponse> Handle(CreateDistrictRequest request, CancellationToken cancellationToken)
        {
            T.District district = new();
            district.CountryId = request.CountryId;
            district.CityId = request.CityId;
            district.Name = request.Name;

            district = await _districtWriteRepository.AddAsync(district);
            await _districtWriteRepository.SaveAsync();

            return new()
            {
                Id = district.Idc,
                CountryId = district.CountryId,
                CityId = district.CityId,
                Name = district.Name,
                Message = CommandResponseMessage.AddedSuccess.ToString(),
            };
        }
    }
}
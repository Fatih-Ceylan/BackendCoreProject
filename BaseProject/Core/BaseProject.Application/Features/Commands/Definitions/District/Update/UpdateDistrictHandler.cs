using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.District.Update
{
    public class UpdateDistrictHandler : IRequestHandler<UpdateDistrictRequest, UpdateDistrictResponse>
    {
        readonly IDistrictReadRepository _districtReadRepository;
        readonly IDistrictWriteRepository _districtWriteRepository;

        public UpdateDistrictHandler(IDistrictReadRepository districtReadRepository, IDistrictWriteRepository districtWriteRepository)
        {
            _districtReadRepository = districtReadRepository;
            _districtWriteRepository = districtWriteRepository;
        }

        public async Task<UpdateDistrictResponse> Handle(UpdateDistrictRequest request, CancellationToken cancellationToken)
        {
            var district = _districtReadRepository.GetAll().Where(d => d.Idc == request.Id).FirstOrDefault();

            if (district != null)
            {
                district.CountryId = request.CountryId;
                district.CityId = request.CityId;
                district.Name = request.Name;
                await _districtWriteRepository.SaveAsync();

                return new()
                {
                    Id = district.Idc,
                    CountryId = district.CountryId,
                    CityId = district.CityId,
                    Name = district.Name,
                    Message = CommandResponseMessage.UpdatedSuccess.ToString(),
                };
            }
            else
               throw new Exception("This district is not registered.");
        }
    }
}
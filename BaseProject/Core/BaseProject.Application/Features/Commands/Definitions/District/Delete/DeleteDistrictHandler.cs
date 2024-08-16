using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.District.Delete
{
    public partial class DeleteDistrictHandler : IRequestHandler<DeleteDistrictRequest, DeleteDistrictResponse>
    {
        readonly IDistrictReadRepository _districtReadRepository;
        readonly IDistrictWriteRepository _districtWriteRepository;

        public DeleteDistrictHandler(IDistrictWriteRepository districtWriteRepository, IDistrictReadRepository districtReadRepository)
        {
            _districtWriteRepository = districtWriteRepository;
            _districtReadRepository = districtReadRepository;
        }

        public async Task<DeleteDistrictResponse> Handle(DeleteDistrictRequest request, CancellationToken cancellationToken)
        {
            var district = _districtReadRepository.GetAll().Where(d => d.Idc == request.Id).FirstOrDefault();

            if (district != null)
            {
                district.IsDeleted = true;
                await _districtWriteRepository.SaveAsync();

                return new()
                {
                    Message = CommandResponseMessage.DeletedSuccess.ToString(),
                };
            }
            else
                throw new Exception("This district is not registered.");

        }
    }
}
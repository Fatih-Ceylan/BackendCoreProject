using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.ApplicationSetting.Update
{
    public class UpdateApplicationSettingHandler : IRequestHandler<UpdateApplicationSettingRequest, UpdateApplicationSettingResponse>
    {
        readonly IApplicationSettingWriteRepository _applicationSettingWriteRepository;
        readonly IApplicationSettingReadRepository _applicationSettingReadRepository;
        readonly IMapper _mapper;

        public UpdateApplicationSettingHandler(IApplicationSettingWriteRepository applicationSettingWriteRepository, IApplicationSettingReadRepository applicationSettingReadRepository, IMapper mapper)
        {
            _applicationSettingWriteRepository = applicationSettingWriteRepository;
            _applicationSettingReadRepository = applicationSettingReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateApplicationSettingResponse> Handle(UpdateApplicationSettingRequest request, CancellationToken cancellationToken)
        {
            var applicationSettiing = await _applicationSettingReadRepository.GetByIdAsync(request.Id);
            applicationSettiing = _mapper.Map(request, applicationSettiing);
            await _applicationSettingWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateApplicationSettingResponse>(applicationSettiing);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

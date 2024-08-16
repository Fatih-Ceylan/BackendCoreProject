using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.ApplicationSetting.Delete
{
    public class DeleteApplicationSettingHandler : IRequestHandler<DeleteApplicationSettingRequest, DeleteApplicationSettingResponse>
    {
        readonly IApplicationSettingWriteRepository _applicationSettingWriteRepository;

        public DeleteApplicationSettingHandler(IApplicationSettingWriteRepository applicationSettingWriteRepository)
        {
            _applicationSettingWriteRepository = applicationSettingWriteRepository;
        }

        public async Task<DeleteApplicationSettingResponse> Handle(DeleteApplicationSettingRequest request, CancellationToken cancellationToken)
        {
            await _applicationSettingWriteRepository.SoftDeleteAsync(request.Id);
            await _applicationSettingWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}

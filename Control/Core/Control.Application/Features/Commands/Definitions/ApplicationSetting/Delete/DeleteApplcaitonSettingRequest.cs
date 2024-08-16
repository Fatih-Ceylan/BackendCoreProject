using MediatR;

namespace GControl.Application.Features.Commands.Definitions.ApplicationSetting.Delete
{
    public class DeleteApplicationSettingRequest : IRequest<DeleteApplicationSettingResponse>
    {
        public string Id { get; set; }
    }
}

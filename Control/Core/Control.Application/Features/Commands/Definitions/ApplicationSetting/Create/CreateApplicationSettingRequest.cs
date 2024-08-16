using MediatR;

namespace GControl.Application.Features.Commands.Definitions.ApplicationSetting.Create
{
    public class CreateApplicationSettingRequest : IRequest<CreateApplicationSettingResponse>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAccepted { get; set; }
        public string CompanyId { get; set; }
    }
}

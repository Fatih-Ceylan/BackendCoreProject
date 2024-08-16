using MediatR;

namespace GControl.Application.Features.Commands.Definitions.ApplicationSetting.Update
{
    public class UpdateApplicationSettingRequest : IRequest<UpdateApplicationSettingResponse>
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAccepted { get; set; }
        public string CompanyId { get; set; } 
    }
}

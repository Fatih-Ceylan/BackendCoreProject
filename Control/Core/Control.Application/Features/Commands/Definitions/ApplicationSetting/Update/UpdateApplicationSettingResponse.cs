namespace GControl.Application.Features.Commands.Definitions.ApplicationSetting.Update
{
    public class UpdateApplicationSettingResponse
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAccepted { get; set; } 
        public string Message { get; set; }
    }
}

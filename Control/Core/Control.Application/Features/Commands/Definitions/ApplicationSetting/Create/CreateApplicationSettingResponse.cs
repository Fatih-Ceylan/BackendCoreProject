namespace GControl.Application.Features.Commands.Definitions.ApplicationSetting.Create
{
    public class CreateApplicationSettingResponse
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAccepted { get; set; }
        public string Message { get; set; }

    }
}

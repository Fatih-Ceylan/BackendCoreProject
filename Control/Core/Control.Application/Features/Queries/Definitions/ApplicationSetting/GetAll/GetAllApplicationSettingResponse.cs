using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.ApplicationSetting.GetAll
{
    public class GetAllApplicationSettingResponse
    {
        public int TotalCount { get; set; }

        public List<ApplicationSettingVM> ApplicationSettings { get; set; }
    }
}

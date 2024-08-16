using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.ApplicationSetting.GetAll
{
    public class GetAllApplicationSettingRequest : Pagination, IRequest<GetAllApplicationSettingResponse>
    {
        public string? CompanyId { get; set; }
    }
}

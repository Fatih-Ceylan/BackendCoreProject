using MediatR;

namespace GControl.Application.Features.Queries.Definitions.ApplicationSetting.GetById
{
    public class GetByIdApplicationSettingRequest : IRequest<GetByIdApplicationSettingResponse>
    {
        public string Id { get; set; }
    }
}

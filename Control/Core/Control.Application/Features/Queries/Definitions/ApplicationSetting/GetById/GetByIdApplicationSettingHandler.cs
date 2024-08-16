using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.ApplicationSetting.GetById
{
    public class GetByIdApplicationSettingHandler : IRequestHandler<GetByIdApplicationSettingRequest, GetByIdApplicationSettingResponse>
    {
        readonly IApplicationSettingReadRepository _applicationSettingReadRepository;

        public GetByIdApplicationSettingHandler(IApplicationSettingReadRepository applicationSettingReadRepository)
        {
            _applicationSettingReadRepository = applicationSettingReadRepository;
        }

        public async Task<GetByIdApplicationSettingResponse> Handle(GetByIdApplicationSettingRequest request, CancellationToken cancellationToken)
        {
            var applicationSetting = _applicationSettingReadRepository
                                .GetWhere(ds => ds.Id == Guid.Parse(request.Id))
                                .Select(ds => new ApplicationSettingVM
                                {
                                    Id = ds.Id.ToString(),
                                    Name = ds.Name,
                                    //BaseProjectBranchId = ds.BaseProjectBranchId.ToString(),
                                    //BaseProjectCompanyId = ds.BaseProjectCompanyId.ToString(),
                                }).FirstOrDefault();
            return new()
            {
                ApplicationSetting = applicationSetting
            };
        }
    }
}

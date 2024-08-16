using AutoMapper;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.ApplicationSetting.Create
{
    public class CreateApplicationSettingHandler : IRequestHandler<CreateApplicationSettingRequest, CreateApplicationSettingResponse>
    {
        readonly IApplicationSettingWriteRepository _applicationSettingWriteRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository _companyReadRepository;
        public CreateApplicationSettingHandler(IApplicationSettingWriteRepository applicationSettingWriteRepository, IMapper mapper, BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository companyReadRepository)
        {
            _applicationSettingWriteRepository = applicationSettingWriteRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<CreateApplicationSettingResponse> Handle(CreateApplicationSettingRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }
            var applicationSetting = _mapper.Map<T.ApplicationSetting>(request);
            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                applicationSetting.CompanyId = mainCompanyId;
            }
            applicationSetting = await _applicationSettingWriteRepository.AddAsync(applicationSetting);
            await _applicationSettingWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateApplicationSettingResponse>(applicationSetting);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

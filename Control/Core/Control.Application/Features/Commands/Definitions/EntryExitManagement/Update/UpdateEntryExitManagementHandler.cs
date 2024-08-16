using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EntryExitManagement.Update
{
    public class UpdateEntryExitManagementHandler : IRequestHandler<UpdateEntryExitManagementRequest, UpdateEntryExitManagementResponse>
    {
        readonly IEntryExitManagementWriteRepository _entryExitManagementWriteRepository;
        readonly IEntryExitManagementReadRepository _entryExitManagementReadRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository _companyReadRepository;

        public UpdateEntryExitManagementHandler(IEntryExitManagementWriteRepository entryExitManagementWriteRepository, IMapper mapper, IEntryExitManagementReadRepository entryExitManagementReadRepository, BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository companyReadRepository)
        {
            _entryExitManagementWriteRepository = entryExitManagementWriteRepository;
            _mapper = mapper;
            _entryExitManagementReadRepository = entryExitManagementReadRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<UpdateEntryExitManagementResponse> Handle(UpdateEntryExitManagementRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }

            T.EntryExitManagement gmodule = await _entryExitManagementReadRepository.GetByIdAsync(request.Id);
            gmodule = _mapper.Map(request, gmodule);
            await _entryExitManagementWriteRepository.SaveAsync();

            var updatedEntryExitManagement = _mapper.Map<UpdateEntryExitManagementResponse>(gmodule);
            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                updatedEntryExitManagement.CompanyId = mainCompanyId.ToString();
            }
            updatedEntryExitManagement.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedEntryExitManagement;
        }
    }
}

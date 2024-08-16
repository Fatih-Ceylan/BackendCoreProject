using AutoMapper;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EntryExitManagement.Create
{
    public class CreateEntryExitManagementHandler : IRequestHandler<CreateEntryExitManagementRequest, CreateEntryExitManagementResponse>
    {
        readonly IEntryExitManagementWriteRepository _EntryExitManagementWriteRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository _companyReadRepository;
        public CreateEntryExitManagementHandler(IEntryExitManagementWriteRepository EntryExitManagementWriteRepository, IMapper mapper, BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository companyReadRepository)
        {
            _EntryExitManagementWriteRepository = EntryExitManagementWriteRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<CreateEntryExitManagementResponse> Handle(CreateEntryExitManagementRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }

            var EntryExitManagement = _mapper.Map<T.EntryExitManagement>(request);
            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                EntryExitManagement.CompanyId = mainCompanyId;
            }
            EntryExitManagement = await _EntryExitManagementWriteRepository.AddAsync(EntryExitManagement);
            await _EntryExitManagementWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateEntryExitManagementResponse>(EntryExitManagement);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

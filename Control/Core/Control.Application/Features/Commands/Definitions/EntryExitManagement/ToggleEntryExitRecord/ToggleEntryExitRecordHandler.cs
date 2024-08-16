using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EntryExitManagement.ToggleEntryExitRecord
{
    public class ToggleEntryExitRecordHandler : IRequestHandler<ToggleEntryExitRecordRequest, ToggleEntryExitRecordResponse>
    {
        readonly IEntryExitManagementWriteRepository _EntryExitManagementWriteRepository;
        readonly IEntryExitManagementReadRepository _EntryExitManagementReadRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository _companyReadRepository;
        public ToggleEntryExitRecordHandler(IEntryExitManagementWriteRepository EntryExitManagementWriteRepository, IMapper mapper, BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository companyReadRepository)
        {
            _EntryExitManagementWriteRepository = EntryExitManagementWriteRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<ToggleEntryExitRecordResponse> Handle(ToggleEntryExitRecordRequest request, CancellationToken cancellationToken)
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

            var existingRecords = _EntryExitManagementReadRepository.GetWhere(x =>
           x.EmployeeId == Guid.Parse(request.EmployeeId) &&
           x.CompanyId == EntryExitManagement.CompanyId &&
           x.BranchId == EntryExitManagement.BranchId &&
           x.LocationId == Guid.Parse(request.LocationId));

            if (existingRecords.Any())
            {
                // Find the record with the latest datetime
                var latestRecord = existingRecords.OrderByDescending(x => x.DateTime).FirstOrDefault();

                if (latestRecord != null)
                {
                    // If the latest record's isRegistrationType is true, set new record's isRegistrationType to false
                    // Otherwise, set it to true
                    EntryExitManagement.IsRegistrationType = !latestRecord.IsRegistrationType;
                }
                else
                {
                    // If no existing records, set a default value (assuming false as default)
                    EntryExitManagement.IsRegistrationType = false;
                }
            }
            EntryExitManagement = await _EntryExitManagementWriteRepository.AddAsync(EntryExitManagement);
            await _EntryExitManagementWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<ToggleEntryExitRecordResponse>(EntryExitManagement);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

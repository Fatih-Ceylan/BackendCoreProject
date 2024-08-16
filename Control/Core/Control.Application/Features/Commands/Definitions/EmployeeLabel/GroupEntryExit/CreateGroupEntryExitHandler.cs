using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupEntryExit
{
    public class CreateGroupEntryExitHandler : IRequestHandler<CreateGroupEntryExitRequest, CreateGroupEntryExitResponse>
    {
        readonly IBranchReadRepository _branchReadRepository;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IEntryExitManagementWriteRepository _EntryExitManagementWriteRepository;
        readonly IEmployeeReadRepository _EmployeeReadRepository;
        readonly ILocationReadRepository _LocationReadRepository;
        readonly IMapper _mapper;
        public CreateGroupEntryExitHandler(IEntryExitManagementWriteRepository EntryExitManagementWriteRepository, IMapper mapper, IEmployeeReadRepository employeeReadRepository, ILocationReadRepository locationReadRepository, ICompanyReadRepository companyReadRepository, IBranchReadRepository branchReadRepository)
        {
            _EntryExitManagementWriteRepository = EntryExitManagementWriteRepository;
            _mapper = mapper;
            _EmployeeReadRepository = employeeReadRepository;
            _LocationReadRepository = locationReadRepository;
            _companyReadRepository = companyReadRepository;
            _branchReadRepository = branchReadRepository;
        }

        public async Task<CreateGroupEntryExitResponse> Handle(CreateGroupEntryExitRequest request, CancellationToken cancellationToken)
        {
            var entryVM = new List<EntryExitManagementVM>();

            foreach (var employeeId in request.EmployeeId)
            {

                var employeeDetails = await _EmployeeReadRepository.GetByIdAsync(employeeId);
                var entryExitManagement = new T.EntryExitManagement
                {
                    EmployeeId = Guid.Parse(employeeId),
                    IsRegistrationType = request.IsRegistrationType,
                    DateTime = request.DateTime,
                    Description = request.Description,
                    LocationId = employeeDetails.LocationId.Value,
                    CompanyId = employeeDetails.CompanyId.Value,
                    BranchId = employeeDetails.BranchId.Value
                };

                var companyDetails = await _companyReadRepository.GetByIdAsync(entryExitManagement.CompanyId.ToString());
                var branchDetails = await _branchReadRepository.GetByIdAsync(entryExitManagement.BranchId.ToString());
                var locationDetails = await _LocationReadRepository.GetByIdAsync(entryExitManagement.LocationId.ToString());
                entryExitManagement = await _EntryExitManagementWriteRepository.AddAsync(entryExitManagement);
                await _EntryExitManagementWriteRepository.SaveAsync();


                var entryExitManagementVM = new EntryExitManagementVM
                {
                    Id = entryExitManagement.Id.ToString(),
                    EmployeeId = entryExitManagement.EmployeeId.ToString(),
                    EmployeeName = employeeDetails != null ? employeeDetails.FullName : null,
                    LocationId = entryExitManagement.LocationId.ToString(),
                    LocationName = locationDetails != null ? locationDetails.Name : null,
                    CompanyId = entryExitManagement.CompanyId.ToString(),
                    CompanyName = companyDetails != null ? companyDetails.Name : null,
                    BranchId = entryExitManagement.BranchId.ToString(),
                    BranchName = branchDetails != null ? branchDetails.Name : null,
                    DateTime = entryExitManagement.DateTime,
                    IsLocationOut = entryExitManagement.IsLocationOut,
                    IsRegistrationType = entryExitManagement.IsRegistrationType,
                    Description = entryExitManagement.Description,
                    //Message = CommandResponseMessage.AddedSuccess.ToString(),
                };

                entryVM.Add(entryExitManagementVM);
            }

            return new CreateGroupEntryExitResponse
            {
                Employees = entryVM
            };
        }
    }
}

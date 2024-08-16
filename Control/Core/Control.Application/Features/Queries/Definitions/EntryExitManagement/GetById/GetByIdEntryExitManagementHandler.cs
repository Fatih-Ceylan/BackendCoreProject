using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.GetById
{
    internal class GetByIdEntryExitManagementHandler : IRequestHandler<GetByIdEntryExitManagementRequest, GetByIdEntryExitManagementResponse>
    {
        readonly IEntryExitManagementReadRepository _entryExitManagementReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly ILocationReadRepository _locationReadRepository;
        public GetByIdEntryExitManagementHandler(IEntryExitManagementReadRepository entryExitManagementReadRepository, IEmployeeReadRepository employeeReadRepository, ILocationReadRepository locationReadRepository)
        {
            _entryExitManagementReadRepository = entryExitManagementReadRepository;
            _employeeReadRepository = employeeReadRepository;
            _locationReadRepository = locationReadRepository;
        }

        public async Task<GetByIdEntryExitManagementResponse> Handle(GetByIdEntryExitManagementRequest request, CancellationToken cancellationToken)
        {
            var employeeList = _employeeReadRepository
                .GetAllDeletedStatusDesc(false)
                .Select(d => new EmployeeVM
                {
                    Id = d.Id.ToString(),
                    FullName = d.FullName
                })
                .ToList();

            var locationList = _locationReadRepository
                .GetAllDeletedStatusDesc(false)
                .Select(d => new LocationVM
                {
                    Id = d.Id.ToString(),
                    Name = d.Name
                })
                .ToList();

            var entryExitManagement = _entryExitManagementReadRepository
                           .GetWhere(eem => eem.Id == Guid.Parse(request.Id), false)
                           .Select(eem => new EntryExitManagementVM
                           {
                               Id = eem.Id.ToString(),
                               EmployeeId = eem.EmployeeId.ToString(),
                               LocationId = eem.LocationId.ToString(),
                               DateTime = eem.DateTime,
                               IsLocationOut = eem.IsLocationOut,
                               IsRegistrationType = eem.IsRegistrationType,
                               Description = eem.Description,
                               //BranchId = eem.BranchId.ToString(),
                               CompanyId =eem.CompanyId.ToString(),
                               //BranchName = eem.Branch != null ? eem.Branch.Name : null,
                               CompanyName = eem.Company != null ? eem.Company.Name : null,
                               CreatedDate = eem.CreatedDate,
                           }).FirstOrDefault();

            entryExitManagement.EmployeeName = employeeList.Where(x => x.Id == entryExitManagement.EmployeeId).Select(a => a.FullName).FirstOrDefault();
            entryExitManagement.LocationName = locationList.Where(x => x.Id == entryExitManagement.LocationId).Select(a => a.Name).FirstOrDefault();

            return new()
            {
                EntryExitManagements = entryExitManagement
            };
        }
    }
}

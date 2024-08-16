using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.LoggedInEmployees
{
    public class LoggedInEmployeesHandler : IRequestHandler<LoggedInEmployeesRequest, LoggedInEmployeesResponse>
    {
        readonly IEntryExitManagementReadRepository _entryExitManagementReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        public LoggedInEmployeesHandler(IEntryExitManagementReadRepository entryExitManagementReadRepository, IEmployeeReadRepository employeeReadRepository)
        {
            _entryExitManagementReadRepository = entryExitManagementReadRepository;
            _employeeReadRepository = employeeReadRepository;
        }
        public Task<LoggedInEmployeesResponse> Handle(LoggedInEmployeesRequest request, CancellationToken cancellationToken)
        {

            var employeeList = _employeeReadRepository.GetAllDeletedStatusDesc(false, false)
               .Select(e => new T.Employee
               {
                   Id = e.Id,
                   FullName = e.FullName,
                   ProfilePicturePath = e.ProfilePicturePath,
               }).ToList();

            var query = _entryExitManagementReadRepository
                        .GetAllDeletedStatusDesc(false)
                        .Select(ds => new EntryExitManagementVM
                        {
                            Id = ds.Id.ToString(),
                            EmployeeId = ds.EmployeeId.ToString(),
                            IsRegistrationType = ds.IsRegistrationType,
                            DateTime = ds.DateTime,
                        }).Where(ds => ds.IsRegistrationType)
                        .OrderByDescending(ds => ds.DateTime)
                        .Take(10);

            var groupedEmployees = _employeeReadRepository.GetAllDeletedStatusDesc(false, false)
                .Join(query, e => e.Id.ToString(),
                            q => q.EmployeeId,
                            (e, q) => new LoggedInEmployeesVM
                            {
                                EmployeeId = e.Id.ToString(),
                                FullName = e.FullName,
                                ProfilePicturePath = e.ProfilePicturePath
                            }).GroupBy(vm => vm.EmployeeId).Select(group => new LoggedInEmployeesVM
                            {
                                EmployeeId = group.Key,
                                FullName = group.First().FullName,
                                ProfilePicturePath = group.First().ProfilePicturePath
                            })
                            .ToList();

            var totalCount = groupedEmployees.Count();

            return Task.FromResult(new LoggedInEmployeesResponse
            {
                TotalCount = totalCount,
                LoggedInEmployees = groupedEmployees,
            });
        }
    }
}

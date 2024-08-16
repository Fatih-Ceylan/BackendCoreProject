using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.NotLoggedInEmployee
{
    public class NotLoggedInEmployeeHandler : IRequestHandler<NotLoggedInEmployeeRequest, NotLoggedInEmployeeResponse>
    {
        readonly IEntryExitManagementReadRepository _entryExitManagementReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        public NotLoggedInEmployeeHandler(IEntryExitManagementReadRepository entryExitManagementReadRepository, IEmployeeReadRepository employeeReadRepository)
        {
            _entryExitManagementReadRepository = entryExitManagementReadRepository;
            _employeeReadRepository = employeeReadRepository;
        }

        public Task<NotLoggedInEmployeeResponse> Handle(NotLoggedInEmployeeRequest request, CancellationToken cancellationToken)
        {
            var entryExitEmployees = _entryExitManagementReadRepository
                .GetAllDeletedStatusDesc(false)
                .Select(ds => ds.EmployeeId.ToString())
                .Distinct(); 

            var query = _employeeReadRepository.GetAllDeletedStatusDesc(false, false)
                .Select(e => new LoggedInEmployeesVM
                {
                    EmployeeId = e.Id.ToString(),
                    FullName = e.FullName,
                    ProfilePicturePath = e.ProfilePicturePath
                })
                .Where(e => !entryExitEmployees.Contains(e.EmployeeId))
                .OrderByDescending(e => e.EmployeeId).Take(10)
                .ToList();

            var totalCount = query.Count();

            return Task.FromResult(new NotLoggedInEmployeeResponse
            {
                TotalCount = totalCount,
                NotLoggedInEmployees = query,
            });
        }
    }
}
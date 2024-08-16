using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.EmployeeEntryInAndOut
{
    public class EmployeesWhoEntriesInAndNotHandler : IRequestHandler<EmployeeEntryInAndOutRequest, EmployeeEntryInAndOutResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEntryExitManagementReadRepository _entryExitManagementReadRepository;

        public EmployeesWhoEntriesInAndNotHandler(IEmployeeReadRepository employeeReadRepository, IEntryExitManagementReadRepository entryExitManagementReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _entryExitManagementReadRepository = entryExitManagementReadRepository;
        }

        public Task<EmployeeEntryInAndOutResponse> Handle(EmployeeEntryInAndOutRequest request, CancellationToken cancellationToken)
        {


            var employeeList = _employeeReadRepository.GetAllDeletedStatusDesc(false, false)
                .Include(e => e.ShiftManagements)
                .Select(e => new T.Employee
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    ShiftManagements = e.ShiftManagements
                }).ToList();

            var result = (from esm in _employeeReadRepository.GetAllDeletedStatusDesc(false, false)
                          join eem in _entryExitManagementReadRepository.GetAllDeletedStatusDesc(false, false)
                          on esm.Id equals eem.EmployeeId
                          from shiftManagement in esm.ShiftManagements // Her ShiftManagement öğesini döngüyle işle
                          group eem by new { shiftManagement.Id, shiftManagement.Title } into g // Gruplamayı ShiftManagement Id'sine göre yap
                          select new EmpEntryInOutVM
                          {
                              ShiftManagementId = g.Key.Id.ToString(),
                              ShiftManagementName = g.Key.Title,
                              LoggedInEemployee = g.Count(e => e.IsRegistrationType == true),
                              NonLoggedInEemployee = g.Count(),
                          }).Select(x => new EmpEntryInOutVM
                          {
                              ShiftManagementId = x.ShiftManagementId,
                              ShiftManagementName = x.ShiftManagementName,
                              LoggedInEemployee = x.LoggedInEemployee,
                              NonLoggedInEemployee = x.NonLoggedInEemployee - x.LoggedInEemployee, // EmployeeCount'ı registrueemployee'den çıkararak hesaplayın
                          }).ToList();

            var totalEmp = employeeList.Count();

            return Task.FromResult(new EmployeeEntryInAndOutResponse
            {
                TotalCount = totalEmp,
                EmpEntryInOuts = result
            });
        }

    }
}

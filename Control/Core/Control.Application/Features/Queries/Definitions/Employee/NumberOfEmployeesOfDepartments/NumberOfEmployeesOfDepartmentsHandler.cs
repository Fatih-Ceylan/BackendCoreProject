using BaseProject.Domain.Entities.GControl.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Employee.NumberOfEmployeesOfDepartments
{
    public class NumberOfEmployeesOfDepartmentsHandler : IRequestHandler<NumberOfEmployeesOfDepartmentsRequest, NumberOfEmployeesOfDepartmentsResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository _departmentReadRepository;
        public NumberOfEmployeesOfDepartmentsHandler(IEmployeeReadRepository employeeReadRepository, BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository departmentReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _departmentReadRepository = departmentReadRepository;
        }

        public Task<NumberOfEmployeesOfDepartmentsResponse> Handle(NumberOfEmployeesOfDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var departmentList = _departmentReadRepository
                .GetAllDesc()
                .Select(d => new DepartmentDDLVM
                {
                    Id = d.Id.ToString(),
                    Name = d.Name
                })
                .ToList();

            List<T.Employee> employees = new List<T.Employee>();

            employees = _employeeReadRepository.GetAllDeletedStatusDesc(false,false).ToList();

            var result = (from e in employees
                          join dept in departmentList on e.DepartmentId.ToString().ToUpper() equals dept.Id into deptJoin
                          from dept in deptJoin.DefaultIfEmpty()
                          select new EmployeeVM
                          {
                              Id = e.Id.ToString(),
                              FullName = e.FullName,
                              EmployeeTypeId = e.EmployeeTypeId.ToString(),
                              DepartmentId = e.DepartmentId.ToString(),
                              DepartmentName = dept != null ? dept.Name : null
                          }).ToList();

            var groupedEmployees = result
                .GroupBy(e => e.DepartmentId)
                .Select(g => new GroupEmployeeVM
                {
                    DepartmentId = g.Key,
                    DepartmentName = departmentList.FirstOrDefault(d => d.Id.ToLower() == g.Key)?.Name,
                    EmployeeCount = g.Count()
                }).ToList();

            return Task.FromResult(new NumberOfEmployeesOfDepartmentsResponse
            {
                TotalCount = employees.Count(),
                Employees = groupedEmployees
            });
        }
    }
}

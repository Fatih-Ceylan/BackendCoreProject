using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GControl.Application.Features.Queries.Definitions.Employee.GetById
{
    public class GetByIdEmployeeHandler : IRequestHandler<GetByIdEmployeeRequest, GetByIdEmployeeResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository _departmentReadRepository;
        public GetByIdEmployeeHandler(IEmployeeReadRepository employeeReadRepository, BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository departmentReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<GetByIdEmployeeResponse> Handle(GetByIdEmployeeRequest request, CancellationToken cancellationToken)
        {
            
            var employee = _employeeReadRepository
                           .GetWhere(e => e.Id == Guid.Parse(request.Id), false)
                           .Include(e => e.EmployeeLabels)
                           .Include(e => e.EmployeeFiles)
                           .Select(e => new EmployeeVM
                           {
                               Id = e.Id.ToString().ToUpper(),
                               RegistrationNumber = e.RegistrationNumber,
                               FullName = e.FullName,
                               PhoneNumber = e.PhoneNumber,
                               StartWorkDate = e.StartWorkDate,
                               Email = e.Email,
                               //EmployeeTypeId = e.EmployeeTypeId.ToString(),
                               //EmployeeTypeName = e.EmployeeType.Name,
                               DepartmentId = e.DepartmentId.ToString(),
                               DepartmentName = e.Department != null ? e.Department.Name : null,
                               isActive = e.isActive,
                               //BranchId = e.BranchId.ToString(),
                               CompanyId = e.CompanyId.ToString(),
                               //BranchName = e.Branch != null ? e.Branch.Name : null,
                               CompanyName = e.Company != null ? e.Company.Name : null,
                               CreatedDate = e.CreatedDate,
                               EmployeeLabelVMs = e.EmployeeLabels.Select(el => new EmployeeLabelVM
                               {
                                   Id = el.Id.ToString(),
                                   Name = el.Name,
                                   CreatedDate = el.CreatedDate
                               }).ToList(),
                               ShiftManagementVMs = e.ShiftManagements.Select(el => new ShiftManagementVM
                               {
                                   Id = el.Id.ToString(),
                                   Title = el.Title,
                               }).ToList(),
                               ApplicationSettingVMs = e.ApplicationSettings.Select(el => new ApplicationSettingVM
                               {
                                   Id = el.Id.ToString(),
                                   Name = el.Name,
                                   Code = el.Code,
                               }).ToList(),
                               EmployeeFiles = e.EmployeeFiles.Select(el => new EmployeeFileVM
                               {
                                   Id = el.Id.ToString(),
                                   PathOrContainerName = el.Path,
                                   FileName = el.FileName,
                                   Storage = el.Storage,
                                   EmployeeId = e.Id.ToString()
                               }).ToList(),
                               EmployeeType = e.EmployeeType != null ? new EmployeeTypeVM
                               {
                                   Id = e.EmployeeType.Id.ToString(),
                                   Name = e.EmployeeType.Name
                               } : null,


                           })
                           .FirstOrDefault();
            return new()
            {
                Employees = employee
            };
        }
    }
}

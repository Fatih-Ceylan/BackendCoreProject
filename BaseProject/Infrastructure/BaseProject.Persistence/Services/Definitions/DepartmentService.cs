using BaseProject.Application.Abstractions.Services.Definitions;
using BaseProject.Application.DTOs.Definitions.Department;
using BaseProject.Application.Repositories.ReadRepository.Definitions;

namespace BaseProject.Persistence.Services.Definitions
{
    public class DepartmentService : IDepartmentService
    {
        readonly IDepartmentReadRepository _departmentReadRepository;

        public DepartmentService(IDepartmentReadRepository departmentReadRepository)
        {
            _departmentReadRepository = departmentReadRepository;
        }

        public DepartmentDTO? GetDepartmentById(string id)
        {
            DepartmentDTO? department = null;
            department = _departmentReadRepository.GetWhere(d => d.Id == Guid.Parse(id))
                                                      .Select(d => new DepartmentDTO
                                                      {
                                                          Id = d.Id.ToString(),
                                                          CompanyId = d.CompanyId.ToString(),
                                                          CompanyName = d.Branch.Company.Name,
                                                          BranchId = d.BranchId.ToString(),
                                                          BranchName = d.Branch.Name,
                                                          Name = d.Name,
                                                          MainDepartmentId = d.MainDepartmentId.ToString(),
                                                          MainDepartmentName = _departmentReadRepository.GetAllDeletedStatus(false,false)
                                                                                                        .Where(md => md.Id == d.MainDepartmentId)
                                                                                                        .Select(md => md.Name)
                                                                                                        .FirstOrDefault(),
                                                          CreatedDate = d.CreatedDate
                                                      })
                                                      .FirstOrDefault();
            return department;
        }
    }
}
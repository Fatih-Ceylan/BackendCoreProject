using BaseProject.Application.VMs.Definitions;
using BaseProject.Domain.Entities.GControl.Definitions;
using GControl.Application.Abstractions.Services;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace GControl.Application.Features.Queries.Definitions.Department.GetAll
{
    public class GetAllDepartmentHandler : IRequestHandler<GetAllDepartmentRequest, GetAllDepartmentResponse>
    {
        readonly IBaseProjectService _baseProjectService;
        readonly IConfiguration _configuration;

        readonly ILocationReadRepository _locationReadRepository;
        readonly IHttpContextAccessor _contextAccessor;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository _baseDepartmentReadRepository;
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetAllDepartmentHandler(IBaseProjectService baseProjectService, ILocationReadRepository locationReadRepository, IConfiguration configuration, IHttpContextAccessor contextAccessor, BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository baseDepartmentReadRepository, IDepartmentReadRepository departmentReadRepository, IEmployeeReadRepository employeeReadRepository)
        {
            _baseProjectService = baseProjectService;
            _configuration = configuration;
            _contextAccessor = contextAccessor;

            _locationReadRepository = locationReadRepository;
            _baseDepartmentReadRepository = baseDepartmentReadRepository;
            _departmentReadRepository = departmentReadRepository;
            _employeeReadRepository = employeeReadRepository;
        }

        public Task<GetAllDepartmentResponse> Handle(GetAllDepartmentRequest request, CancellationToken cancellationToken)
        {

            var locationList = _locationReadRepository
                .GetAllDeletedStatusDesc(false)
                .Select(d => new LocationVM
                {
                    Id = d.Id.ToString(),
                    Name = d.Name
                })
                .ToList();

            var departments = _baseDepartmentReadRepository
                            .GetAllDeletedStatusDesc(false)
                            .Select(d => new DepartmentDropdownListVM
                            {
                                Id = d.Id.ToString(),
                                Name = d.Name,
                            })
                            .ToList();

            var employeesPerDepartment = _employeeReadRepository.GetAll().GroupBy(e => e.DepartmentId).ToDictionary(g => g.Key.ToString(), g => g.Count());

            var query = _departmentReadRepository
                .GetAllDeletedStatusDesc(false)
                .Select(eem => new DepartmentDDLVM
                {
                    Id = eem.Id.ToString(),
                    LocationId = eem.LocationId.ToString(),
                    BaseDepartmentId = eem.BaseDepartmentId.ToString(),
                    isActive = eem.isActive,
                    EmployeeCount = employeesPerDepartment.ContainsKey(eem.BaseDepartmentId.ToString().ToLower()) ? employeesPerDepartment[eem.BaseDepartmentId.ToString().ToLower()] : 0 // Departmana bağlı çalışan sayısı
                })
                .ToList();

            var result = (from e in query
                          join emp in departments on e.BaseDepartmentId equals emp.Id
                          join loc in locationList on e.LocationId equals loc.Id
                          select new DepartmentDDLVM
                          {
                              Id = e.Id.ToString(),
                              LocationId = e.LocationId,
                              LocationName = loc.Name,
                              BaseDepartmentId=e.BaseDepartmentId.ToString(),
                              BaseDepartmentName = emp.Name,
                              isActive = e.isActive,
                              EmployeeCount = e.EmployeeCount
                          })
                          .Skip(request.Page * request.Size)
                          .Take(request.Size)
                          .ToList();

            if (!string.IsNullOrEmpty(request.FilterText))
            {
                var filterText = request.FilterText.ToLower();

                result = result.Where(e => e.BaseDepartmentName.ToLower().Contains(filterText) ||
                                            e.LocationName.ToLower().Contains(filterText)).ToList();
            }

            var totalCount = query.Count();

            return Task.FromResult(new GetAllDepartmentResponse
            {
                TotalCount = totalCount,
                Departments = result,
            });
        }
    }
 }


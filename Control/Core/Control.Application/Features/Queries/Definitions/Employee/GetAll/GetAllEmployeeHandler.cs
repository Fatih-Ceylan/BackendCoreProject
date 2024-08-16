using AutoMapper;
using BaseProject.Domain.Entities.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Employee.GetAll
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequest, GetAllEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeReadRepository _employeeReadRepository;

        public GetAllEmployeeHandler(IEmployeeReadRepository employeeReadRepository, IMapper mapper)
        {
            _employeeReadRepository = employeeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllEmployeeResponse> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
        {
            var queryable = _employeeReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);

            if (request.CompanyId != "SelectAll")
            {
                queryable = queryable.Where(e => e.CompanyId == Guid.Parse(request.CompanyId));
            }

            IQueryable<EmployeeNewBaseVM> query = queryable.Select(e => new EmployeeNewBaseVM
            {
                Id = e.Id.ToString(),
                RegistrationNumber = e.RegistrationNumber,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                StartWorkDate = e.StartWorkDate,
                Email = e.Email,
                CompanyId = e.CompanyId.ToString(),
                isActive = e.isActive,
                isDeleted = e.IsDeleted,
                UserName = e.UserName,
                Password = e.Password,
                CreatedDate = e.CreatedDate,
                Department = e.Department != null ? new BaseProject.Domain.Entities.Definitions.Department
                {
                    Id = e.Department.Id,
                    Name = e.Department.Name
                } : null,
                Location = e.Location != null ? new LocationVM
                {
                    Id = e.Location.Id.ToString(),
                    Name = e.Location.Name
                } : null,
                EmployeeType = e.EmployeeType != null ? new EmployeeTypeVM
                {
                    Id = e.EmployeeType.Id.ToString(),
                    Name = e.EmployeeType.Name
                } : null,
                Company = e.Company != null ? new Company
                {
                    Id = e.Company.Id,
                    Name = e.Company.Name
                } : null,
                EmployeeLabels = e.EmployeeLabels.Select(el => new EmployeeLabelVM
                {
                    Id = el.Id.ToString(),
                    Name = el.Name,
                    CreatedDate = el.CreatedDate
                }).ToList(),
                ShiftManagements = e.ShiftManagements.Select(el => new ShiftManagementVM
                {
                    Id = el.Id.ToString(),
                    Title = el.Title
                }).ToList(),
                ApplicationSettings = e.ApplicationSettings.Select(el => new ApplicationSettingVM
                {
                    Id = el.Id.ToString(),
                    Name = el.Name,
                    Code = el.Code
                }).ToList(),
                EmployeeFiles = e.EmployeeFiles.Select(el => new EmployeeFileVM
                {
                    Id = el.Id.ToString(),
                    PathOrContainerName = el.Path,
                    FileName = el.FileName,
                    Storage = el.Storage,
                    EmployeeId = e.Id.ToString()
                }).ToList()
            });

            var totalCount = query.Count();
            var filteredQuery = query;

            if (!string.IsNullOrEmpty(request.FilterText))
            {
                filteredQuery = query.Where(x =>
                    x.Email.Contains(request.FilterText) ||
                    x.FullName.Contains(request.FilterText) ||
                    x.RegistrationNumber.Contains(request.FilterText) ||
                    x.PhoneNumber.Contains(request.FilterText) ||
                    x.EmployeeType.Name.Contains(request.FilterText) ||
                    x.Location.Name.Contains(request.FilterText) ||
                    x.Department.Name.Contains(request.FilterText)
                );
                totalCount = filteredQuery.Count();
            }

            var pagedQuery = filteredQuery.Skip(request.Page * request.Size)
                                         .Take(request.Size)
                                         .ToList();

            var employees = _mapper.Map<List<EmployeeNewBaseVM>>(pagedQuery);

            return new GetAllEmployeeResponse
            {
                TotalCount = totalCount,
                Employees = employees
            };
        }
    }
}

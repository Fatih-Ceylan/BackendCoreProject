using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.GetAll
{
    public class GetAllEntryExitManagementHandler : IRequestHandler<GetAllEntryExitManagementRequest, GetAllEntryExitManagementResponse>
    {
        readonly IEntryExitManagementReadRepository _entryExitManagementReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly ILocationReadRepository _locationReadRepository;
        public GetAllEntryExitManagementHandler(IEntryExitManagementReadRepository entryExitManagementReadRepository, IEmployeeReadRepository employeeReadRepository, ILocationReadRepository locationReadRepository)
        {
            _entryExitManagementReadRepository = entryExitManagementReadRepository;
            _employeeReadRepository = employeeReadRepository;
            _locationReadRepository = locationReadRepository;
        }

        public async Task<GetAllEntryExitManagementResponse> Handle(GetAllEntryExitManagementRequest request, CancellationToken cancellationToken)
        {
            var entryExitQuery = _entryExitManagementReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);

            if (request.CompanyId != "SelectAll")
            {
                entryExitQuery = entryExitQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.CompanyId != "SelectAll")
            {
                entryExitQuery = entryExitQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }

            var result =  entryExitQuery.Select(e => new EntryExitManagementVM
                          {
                              Id = e.Id.ToString(),
                              EmployeeId = e.EmployeeId.ToString(),
                              EmployeeName = e.Employee.FullName,
                              LocationId = e.LocationId.ToString(),
                              LocationName = e.Location.Name,
                              CompanyId = e.CompanyId.ToString(),
                              CompanyName = e.Company.Name,
                              DateTime = e.DateTime,
                              IsLocationOut = e.IsLocationOut,
                              IsRegistrationType = e.IsRegistrationType,
                              Description = e.Description,
                              CreatedDate = e.CreatedDate,
                              EmployeeType = e.Employee.EmployeeType != null ? new EmployeeTypeVM
                              {
                                Id = e.Employee.EmployeeTypeId.ToString(),
                                Name = e.Employee.EmployeeType.Name,
                              } : null,
                              RegistrationNumber = e.Employee.RegistrationNumber

            }).ToList();


            if (!string.IsNullOrEmpty(request.FilterText))
            {
                var filterText = request.FilterText.Trim().ToLower();

                if (filterText == "Giris" || filterText == "giris" ||  filterText == "GİRİS" || filterText == "Giriş" || filterText == "giriş" || filterText == "GİRİŞ")
                    result = result.Where(e => e.IsRegistrationType).ToList();
                else if (filterText == "Çıkış" || filterText == "ÇIKIŞ" || filterText == "çıkış" || filterText == "Cikis" || filterText == "CIKIS" || filterText == "cıkıs")
                    result = result.Where(e => !e.IsRegistrationType).ToList();

               else if (filterText == "Evet" || filterText == "evet" || filterText == "EVET")
                    result = result.Where(e => e.IsLocationOut).ToList();
                else if (filterText == "Hayır" || filterText == "hayır" || filterText == "HAYIR")
                    result = result.Where(e => !e.IsLocationOut).ToList();

                else
                {
                    result = result.Where(e =>
                        e.EmployeeName.ToLower().Contains(filterText) ||
                        e.LocationName.ToLower().Contains(filterText)
                    ).ToList();
                }
            }

            result = request.IsDeleted ? result.Skip(request.Page * request.Size)
                                              .Take(request.Size).ToList()
                                       : result.ToList();


            var totalCount = result.Count();

            return new GetAllEntryExitManagementResponse
            {
                TotalCount = totalCount,
                EntryExitManagements = result,
            };
        }
    }
}

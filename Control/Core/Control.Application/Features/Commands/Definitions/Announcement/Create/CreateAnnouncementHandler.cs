using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using DepartmentVM = BaseProject.Domain.Entities.GControl.Definitions.DepartmentVM;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.Announcement.Create
{
    public class CreateAnnouncementHandler : IRequestHandler<CreateAnnouncementRequest, CreateAnnouncementResponse>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IEmployeeLabelWriteRepository _employeeLabelWriteRepository;
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;
        readonly IAnnouncementWriteRepository _announcementWriteRepository;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository _companyReadRepository;
        readonly IMapper _mapper;

        private Guid? _mainCompanyId;
        public CreateAnnouncementHandler(IAnnouncementWriteRepository announcementWriteRepository, IMapper mapper, IEmployeeLabelReadRepository employeeLabelReadRepository, IEmployeeLabelWriteRepository employeeLabelWriteRepository, IDepartmentReadRepository departmentReadRepository, BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository companyReadRepository)
        {
            _announcementWriteRepository = announcementWriteRepository;
            _mapper = mapper;
            _employeeLabelReadRepository = employeeLabelReadRepository;
            _employeeLabelWriteRepository = employeeLabelWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<CreateAnnouncementResponse> Handle(CreateAnnouncementRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = Guid.Empty.ToString();
            }

            var announcement = _mapper.Map<T.Announcement>(request);

            if (!string.IsNullOrEmpty(request.CompanyId))
            {


                if (request.CompanyId == Guid.Empty.ToString())
                {
                    _mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                    announcement.CompanyId = _mainCompanyId;
                }
                else
                {
                    _mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                    announcement.CompanyId = _mainCompanyId;
                }
            }

            if (request.EmployeeLabelsId.Count > 0)
            {
                foreach (var employeeLabelId in request.EmployeeLabelsId)
                {
                    var employeeLabel = await _employeeLabelReadRepository.GetByIdAsync(employeeLabelId);

                    if (employeeLabel != null)
                    {
                        announcement.EmployeeLabels.Add(employeeLabel);
                    }
                }
            }

            if (_mainCompanyId.HasValue)
            {
                var departmentList = _departmentReadRepository.GetAllDeletedStatus();

                foreach (var department in departmentList)
                {
                    announcement.Departments.Add(department);
                }
            }

            else if (request.BaseDepartmentsId.Count > 0)
            {
                foreach (var BaseDepartmentId in request.BaseDepartmentsId)
                {
                    var department =  _departmentReadRepository.GetWhere(x => x.BaseDepartmentId == Guid.Parse(BaseDepartmentId)).FirstOrDefault();

                    if (department != null)
                    {
                        announcement.Departments.Add(department);
                    }
                }
            }
            announcement = await _announcementWriteRepository.AddAsync(announcement);

            var createdResponse = _mapper.Map<CreateAnnouncementResponse>(announcement);
            if (request.EmployeeLabelsId.Count > 0)
            {
                var employeeLabelList = _employeeLabelReadRepository
                           .GetAllDeletedStatusDesc(false)
                           .Where(d => request.EmployeeLabelsId.Contains(d.Id.ToString()))
                           .Select(d => new EmployeeLabelVM
                           {
                               Id = d.Id.ToString(),
                               Name = d.Name,
                               CreatedDate = d.CreatedDate,
                           }).ToList();

                createdResponse.EmployeeLabelsId = employeeLabelList;
            }

            if (request.BaseDepartmentsId.Count > 0)
            {
                var departmentList = _departmentReadRepository
                           .GetAllDeletedStatusDesc(false)
                           .Where(d => request.BaseDepartmentsId.Contains(d.BaseDepartmentId.ToString()))
                           .Select(d => new DepartmentVM
                           {
                               Id = d.Id,
                               Name = d.BaseDepartment.Name,
                               CreatedDate = d.CreatedDate,
                           }).ToList();

                createdResponse.BaseDepartmentsId = departmentList;
            }
            await _announcementWriteRepository.SaveAsync();

            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

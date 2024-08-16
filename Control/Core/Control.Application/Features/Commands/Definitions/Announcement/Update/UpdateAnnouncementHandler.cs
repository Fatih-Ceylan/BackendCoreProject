using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using DepartmentVM = BaseProject.Domain.Entities.GControl.Definitions.DepartmentVM;
using T = BaseProject.Domain.Entities.GControl.Definitions;
namespace GControl.Application.Features.Commands.Definitions.Announcement.Update
{
    public class UpdateAnnouncementHandler : IRequestHandler<UpdateAnnouncementRequest, UpdateAnnouncementResponse>
    {
        readonly IDepartmentReadRepository _DepartmentreadRepository;
        readonly IEmployeeLabelReadRepository _EmployeeLabelReadRepository;
        readonly IAnnouncementWriteRepository _announcementWriteRepository;
        readonly IAnnouncementReadRepository _announcementReadRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository _companyReadRepository;
        public UpdateAnnouncementHandler(IAnnouncementWriteRepository announcementWriteRepository, IAnnouncementReadRepository announcementReadRepository, IMapper mapper, IEmployeeLabelReadRepository employeeLabelReadRepository, IDepartmentReadRepository departmentreadRepository, BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository companyReadRepository)
        {
            _announcementWriteRepository = announcementWriteRepository;
            _announcementReadRepository = announcementReadRepository;
            _mapper = mapper;
            _EmployeeLabelReadRepository = employeeLabelReadRepository;
            _DepartmentreadRepository = departmentreadRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<UpdateAnnouncementResponse> Handle(UpdateAnnouncementRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }
            var announcement = await _announcementReadRepository.GetByIdAsyncIncluding([e => e.EmployeeLabels, e => e.Departments], request.Id);
            var Announcement = _mapper.Map<T.Announcement>(announcement);

            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                announcement.CompanyId = mainCompanyId;
            }

            var employeeLabelList = _EmployeeLabelReadRepository.GetAllDeletedStatus(true, false);
            var departmentList = _DepartmentreadRepository.GetAllDeletedStatus(true, false);

            if (request.EmployeeLabelsId.Count > 0)
            {
                var employeeLabelsToAdd = employeeLabelList.Where(e => request.EmployeeLabelsId.Contains(e.Id.ToString())).ToList();
                announcement.EmployeeLabels.Clear();
                foreach (var label in employeeLabelsToAdd)
                {
                    announcement.EmployeeLabels.Add(label);
                }
            }

            if (request.BaseDepartmentsId.Count > 0)
            {
                var departmentsToAdd = departmentList.Where(e => request.BaseDepartmentsId.Contains(e.Id.ToString())).ToList();
                announcement.Departments.Clear();
                foreach (var department in departmentsToAdd)
                {
                    announcement.Departments.Add(department);
                }
            }

            var createdResponse = _mapper.Map<UpdateAnnouncementResponse>(Announcement);
            if (request.EmployeeLabelsId.Count > 0)
            {
                var employeeLabelList2 = _EmployeeLabelReadRepository
                           .GetAllDeletedStatusDesc(false)
                           .Where(d => request.EmployeeLabelsId.Contains(d.Id.ToString()))
                           .Select(d => new EmployeeLabelVM
                           {
                               Id = d.Id.ToString(),
                               Name = d.Name,
                               CreatedDate = d.CreatedDate,
                           }).ToList();

                createdResponse.EmployeeLabelsId = employeeLabelList2;
            }
            if (request.BaseDepartmentsId.Count > 0)
            {
                var departmentList2= _DepartmentreadRepository
                           .GetAllDeletedStatusDesc(false)
                           .Where(d => request.BaseDepartmentsId.Contains(d.BaseDepartmentId.ToString()))
                           .Select(d => new DepartmentVM
                           {
                               Id = d.Id,
                               Name = d.BaseDepartment.Name,
                           }).ToList();

                createdResponse.BaseDepartmentsId = departmentList2;
            }
            announcement = _mapper.Map(request, announcement);
            await _announcementWriteRepository.SaveAsync();

            createdResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return createdResponse;
        }
    }
}

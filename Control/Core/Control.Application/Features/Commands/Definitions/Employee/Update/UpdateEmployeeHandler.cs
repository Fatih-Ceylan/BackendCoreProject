using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.Employee.Update
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
    {
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeLabelReadRepository _EmployeeLabelReadRepository;
        readonly IShiftManagementReadRepository _ShiftManagementReadRepository;
        readonly IApplicationSettingReadRepository _ApplicationSettingReadRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;


        public UpdateEmployeeHandler(IEmployeeWriteRepository employeeWriteRepository, IMapper mapper, IEmployeeReadRepository employeeReadRepository, IEmployeeLabelWriteRepository employeeLabelWriteRepository, IEmployeeLabelReadRepository employeeLabelReadRepository, IShiftManagementReadRepository shiftManagementReadRepository, IStorageService storageService, IApplicationSettingReadRepository applicationSettingReadRepository)
        {
            _employeeWriteRepository = employeeWriteRepository;
            _mapper = mapper;
            _employeeReadRepository = employeeReadRepository;
            _EmployeeLabelReadRepository = employeeLabelReadRepository;
            _ShiftManagementReadRepository = shiftManagementReadRepository;
            _ApplicationSettingReadRepository = applicationSettingReadRepository;
            _storageService = storageService;
        }

        public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsyncIncluding([e => e.EmployeeLabels, e => e.ShiftManagements, e => e.ApplicationSettings], request.Id);


            var Employee = _mapper.Map<T.Employee>(employee);
            var employeeLabelList = _EmployeeLabelReadRepository.GetAllDeletedStatus(true, false);
            var employeeShiftManagementList = _ShiftManagementReadRepository.GetAllDeletedStatus(true, false);
            var employeeApplicationSettingList = _ApplicationSettingReadRepository.GetAllDeletedStatus(true, false);

            if (request.EmployeeLabelsId.Count > 0)
            {
                var employeeLabelsToAdd = employeeLabelList.Where(e => request.EmployeeLabelsId.Contains(e.Id.ToString())).ToList();
                employee.EmployeeLabels.Clear();
                foreach (var label in employeeLabelsToAdd)
                {
                    employee.EmployeeLabels.Add(label);
                }
            }

            if (request.ShiftManagementsId.Count > 0)
            {
                var employeeShiftManagementsToAdd = employeeShiftManagementList.Where(e => request.ShiftManagementsId.Contains(e.Id.ToString())).ToList();
                employee.ShiftManagements.Clear();
                foreach (var shift in employeeShiftManagementsToAdd)
                {
                    employee.ShiftManagements.Add(shift);
                }
            }

            if (request.ApplicationSettingsId.Count > 0)
            {
                var employeeApplicationSettingsToAdd = employeeApplicationSettingList.Where(e => request.ApplicationSettingsId.Contains(e.Id.ToString())).ToList();
                employee.ApplicationSettings.Clear();
                foreach (var applicationSetting in employeeApplicationSettingsToAdd)
                {
                    employee.ApplicationSettings.Add(applicationSetting);
                }
            }

            var createdResponse = _mapper.Map<UpdateEmployeeResponse>(Employee);

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
            if (request.ShiftManagementsId.Count > 0)
            {
                var shiftManagementList = _ShiftManagementReadRepository
                           .GetAllDeletedStatusDesc(false)
                           .Where(d => request.ShiftManagementsId.Contains(d.Id.ToString()))
                           .Select(d => new ShiftManagementVM
                           {
                               Id = d.Id.ToString(),
                               Title = d.Title,
                               CreatedDate = d.CreatedDate,
                           }).ToList();

                createdResponse.ShiftManagementsId = shiftManagementList;
            }

            if (request.ApplicationSettingsId.Count > 0)
            {
                var applicationSettingsList = _ApplicationSettingReadRepository
                           .GetAllDeletedStatusDesc(false)
                           .Where(d => request.ApplicationSettingsId.Contains(d.Id.ToString()))
                           .Select(d => new ApplicationSettingVM
                           {
                               Id = d.Id.ToString(),
                               Name = d.Name,
                               CreatedDate = d.CreatedDate,
                           }).ToList();

                createdResponse.ApplicationSettingsId = applicationSettingsList;
            }

            string[] fileName;

            if (Employee.ProfilePicturePath != null)
            {
                fileName = Employee.ProfilePicturePath.Split('\\') != null ? Employee.ProfilePicturePath.Split('\\') : new string[] { "" };

                if (request.ProfilePicturePath == null && request.Files == null)
                {
                    try
                    {
                        await _storageService.DeleteAsync(fileName[0], fileName[1]);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    Employee.ProfilePicturePath = null;
                }
            }

            if (request.Files != null)
            {
                List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
                if (request.Files.Count > 0)
                    uploadedDatas = await _storageService.UploadAsync("Employee-ProfilePictures", request.Files);

                request.ProfilePicturePath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : null;
            }

            Employee = _mapper.Map(request, Employee);

            await _employeeWriteRepository.SaveAsync();

            createdResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return createdResponse;
        }
    }
}

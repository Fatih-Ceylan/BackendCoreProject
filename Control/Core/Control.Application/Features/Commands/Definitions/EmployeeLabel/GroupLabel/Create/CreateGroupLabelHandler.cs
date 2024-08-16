using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;
namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupLabel.Create
{
    public class CreateLabelGroupHandler : IRequestHandler<CreateLabelGroupRequest, CreateLabelGroupResponse>
    {
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IMapper _mapper;

        public CreateLabelGroupHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository, IEmployeeLabelReadRepository employeeLabelReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _mapper = mapper;
            _employeeReadRepository = employeeReadRepository;
            _employeeLabelReadRepository = employeeLabelReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<CreateLabelGroupResponse> Handle(CreateLabelGroupRequest request, CancellationToken cancellationToken)
        {

            var employees = await _employeeReadRepository.GetAllDeletedStatusIncluding([e => e.EmployeeLabels]).ToListAsync();
            var groupEmpLabelVM = new List<GroupEmployeeLabelVM>();
            foreach (var employeeId in request.EmployeesId)
            {
                var employee = employees.FirstOrDefault(e => e.Id == Guid.Parse(employeeId));

                if (employee != null)
                {
                    foreach (var employeeLabelId in request.EmployeeLabelsId)
                    {
                        var employeeLabel = employee.EmployeeLabels.FirstOrDefault(el => el.Id == Guid.Parse(employeeLabelId));

                        employeeLabel = await _employeeLabelReadRepository.GetByIdAsync(employeeLabelId);
                        if (employeeLabel != null)
                        {
                            var newEmp = new GroupEmployeeLabelVM
                            {

                                EmployeeId = employeeId,
                                EmployeeName = employee.FullName,
                                LabelId = employeeLabelId,
                                LabelName = employeeLabel.Name,
                            };

                            employee.EmployeeLabels.Add(employeeLabel);
                            groupEmpLabelVM.Add(newEmp);
                        }
                    }
                    _employeeWriteRepository.Update(employee);
                }

                await _employeeWriteRepository.SaveAsync();

                //TODO: yukarıdaki sorgu aşağıdaki şekilde çalıştırılacak. Performansı ölçülecek ve toplu kayıt atarken hatalar teker teker handle edilecek.
                #region onur
                //var employeeQuery = _employeeReadRepository.GetAllDeletedStatus(false);

                //foreach (var item in request.EmployeesId)
                //{
                //    employeeQuery = employeeQuery.Where(e => request.EmployeesId.Contains(e.Id.ToString()));
                //}

                //var employees = employeeQuery.ToList();

                //var employeeLabelQuery = _employeeLabelReadRepository.GetAllDeletedStatus(false);

                //foreach (var item in request.EmployeeLabelsId)
                //{
                //    employeeLabelQuery = employeeLabelQuery.Where(el => request.EmployeeLabelsId.Contains(el.Id.ToString()));
                //}

                //var employeeLabels = employeeLabelQuery.ToList();

                //foreach (var item in employees)
                //{
                //    item.EmployeeLabels = employeeLabels;
                //}

                //_employeeWriteRepository.UpdateRange(employees);
                //await _employeeWriteRepository.SaveAsync(); 
                #endregion

            }
            return new()
            {
                Employees = groupEmpLabelVM,
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }
    }
}

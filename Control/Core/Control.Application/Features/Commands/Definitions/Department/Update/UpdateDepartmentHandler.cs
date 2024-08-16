using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.Department.Update
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentRequest, UpdateDepartmentResponse>
    {
        readonly IDepartmentWriteRepository _departmentWriteRepository;
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository _baseDepartmentReadRepository;
        readonly ILocationReadRepository _locationReadRepository;

        public UpdateDepartmentHandler(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository, IMapper mapper, ILocationReadRepository locationReadRepository, BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository baseDepartmentReadRepository)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
            _locationReadRepository = locationReadRepository;
            _baseDepartmentReadRepository = baseDepartmentReadRepository;
        }

        public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = await _departmentReadRepository.GetByIdAsync(request.Id);
            department = _mapper.Map(request, department);
            var baseDepartment = await _baseDepartmentReadRepository.GetByIdAsync(request.BaseDepartmentId);
            var location = await _locationReadRepository.GetByIdAsync(request.LocationId);
            //var departmentList = _departmentReadRepository.GetAllDeletedStatus(false, false).ToList();
            await _departmentWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateDepartmentResponse>(department);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();
            updatedResponse.BaseDepartmentName = baseDepartment.Name;
            updatedResponse.LocationName = location.Name;
            return updatedResponse;
        }
    }
}

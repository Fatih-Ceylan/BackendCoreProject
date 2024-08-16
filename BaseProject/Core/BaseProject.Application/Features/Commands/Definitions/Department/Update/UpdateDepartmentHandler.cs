using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.Department.Update
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentRequest, UpdateDepartmentResponse>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IDepartmentWriteRepository _departmentWriteRepository;
        readonly IMapper _mapper;

        public UpdateDepartmentHandler(IDepartmentReadRepository departmentReadRepository, IDepartmentWriteRepository departmentWriteRepository, IMapper mapper)
        {
            _departmentReadRepository = departmentReadRepository;
            _departmentWriteRepository = departmentWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            T.Department department = await _departmentReadRepository.GetByIdAsync(request.Id);
            department = _mapper.Map(request, department);

            await _departmentWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateDepartmentResponse>(department);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
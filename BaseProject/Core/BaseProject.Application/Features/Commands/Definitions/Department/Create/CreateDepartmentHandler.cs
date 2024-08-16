using AutoMapper;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.Department.Create
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
    {
        readonly IDepartmentWriteRepository _departmentWriteRepository;
        readonly IMapper _mapper;

        public CreateDepartmentHandler(IDepartmentWriteRepository departmentWriteRepository, IMapper mapper)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateDepartmentResponse> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            T.Department department = _mapper.Map<T.Department>(request);

            department = await _departmentWriteRepository.AddAsync(department);
            await _departmentWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateDepartmentResponse>(department);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
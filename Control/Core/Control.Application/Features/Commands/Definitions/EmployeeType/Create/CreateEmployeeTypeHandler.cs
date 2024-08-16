using AutoMapper;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EmployeeType.Create
{
    public class CreateEmployeeTypeHandler : IRequestHandler<CreateEmployeeTypeRequest, CreateEmployeeTypeResponse>
    {
        readonly IEmployeeTypeWriteRepository _employeeTypeWriteRepository;
        readonly IMapper _mapper;

        public CreateEmployeeTypeHandler(IEmployeeTypeWriteRepository employeeTypeWriteRepository, IMapper mapper)
        {
            _employeeTypeWriteRepository = employeeTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateEmployeeTypeResponse> Handle(CreateEmployeeTypeRequest request, CancellationToken cancellationToken)
        {
            var employeeType = _mapper.Map<T.EmployeeType>(request);

            employeeType = await _employeeTypeWriteRepository.AddAsync(employeeType);
            await _employeeTypeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateEmployeeTypeResponse>(employeeType);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

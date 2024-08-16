using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.HR.Employment;

namespace HR.Application.Features.Commands.Definitions.Employment.Employee.Create
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        readonly IEmployeeWriteRepository _EmployeeWriteRepository;
        readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeeWriteRepository EmployeeWriteRepository, IMapper mapper)
        {
            _EmployeeWriteRepository = EmployeeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var Employee = _mapper.Map<T.Employee>(request);

            Employee = await _EmployeeWriteRepository.AddAsync(Employee);
            await _EmployeeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateEmployeeResponse>(Employee);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

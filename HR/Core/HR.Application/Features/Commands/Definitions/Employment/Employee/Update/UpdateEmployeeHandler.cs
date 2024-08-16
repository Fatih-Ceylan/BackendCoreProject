using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using System.Text.Json;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.Employee.Update
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
    {
        public IMapper _mapper;
        public IEmployeeReadRepository _employeeReadRepository;
        public IEmployeeWriteRepository _employeeWriteRepository;
        //private IDistributedCache _distributedCache;

        public UpdateEmployeeHandler(IMapper mapper, IEmployeeReadRepository EmployeeReadRepository, IEmployeeWriteRepository EmployeeWriteRepository/*, IDistributedCache distributedCache*/)
        {
            _mapper = mapper;
            _employeeReadRepository = EmployeeReadRepository;
            _employeeWriteRepository = EmployeeWriteRepository;
            //_distributedCache = distributedCache;
        }

        public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await _employeeReadRepository.GetByIdAsync(request.Id);
            employee = _mapper.Map(request, employee);
            await _employeeWriteRepository.SaveAsync();

            string cacheKey = request.Id;
            string updatedSerializedData = JsonSerializer.Serialize(employee);
            //await _distributedCache.SetStringAsync(cacheKey, updatedSerializedData, cancellationToken);

            var updatedResponse = _mapper.Map<UpdateEmployeeResponse>(employee);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

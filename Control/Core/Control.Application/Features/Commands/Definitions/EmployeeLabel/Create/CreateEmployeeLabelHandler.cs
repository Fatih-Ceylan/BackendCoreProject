using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.Create
{
    public class CreateEmployeeLabelHandler : IRequestHandler<CreateEmployeeLabelRequest, CreateEmployeeLabelResponse>
    {
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;
        readonly IEmployeeLabelWriteRepository _employeeLabelWriteRepository;
        readonly IMapper _mapper;

        public CreateEmployeeLabelHandler(IEmployeeLabelWriteRepository employeeLabelWriteRepository, IMapper mapper, IEmployeeLabelReadRepository employeeLabelReadRepository)
        {
            _employeeLabelWriteRepository = employeeLabelWriteRepository;
            _mapper = mapper;
            _employeeLabelReadRepository = employeeLabelReadRepository;
        }

        public async Task<CreateEmployeeLabelResponse> Handle(CreateEmployeeLabelRequest request, CancellationToken cancellationToken)
        {

            var existingLabel = _employeeLabelReadRepository.GetWhere(l => l.Name == request.Name).FirstOrDefault();
            if (existingLabel != null)
            {
                
                var warningResponse = new CreateEmployeeLabelResponse
                {
                    Message = "Bu isimde bir etiket zaten mevcut. Kayıt yapılmadı."
                };
                return warningResponse;
            }

            var employeeLabel = _mapper.Map<T.EmployeeLabel>(request);
            employeeLabel = await _employeeLabelWriteRepository.AddAsync(employeeLabel);
            await _employeeLabelWriteRepository.SaveAsync();



            var createdResponse = _mapper.Map<CreateEmployeeLabelResponse>(employeeLabel);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

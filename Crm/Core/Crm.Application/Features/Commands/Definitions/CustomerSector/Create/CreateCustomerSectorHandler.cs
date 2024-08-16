using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSector.Create
{
    public class CreateCustomerSectorHandler : IRequestHandler<CreateCustomerSectorRequest, CreateCustomerSectorResponse>
    {
        readonly ICustomerSectorWriteRepository _customerSectorWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerSectorHandler(ICustomerSectorWriteRepository customerSectorWriteRepository, IMapper mapper)
        {
            _customerSectorWriteRepository = customerSectorWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerSectorResponse> Handle(CreateCustomerSectorRequest request, CancellationToken cancellationToken)
        {
            var customerSector = _mapper.Map<T.CustomerManagement.Customers.CustomerSector>(request);

            customerSector = await _customerSectorWriteRepository.AddAsync(customerSector);
            await _customerSectorWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerSectorResponse>(customerSector);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
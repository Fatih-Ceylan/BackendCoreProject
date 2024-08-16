using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;


namespace GCrm.Application.Features.Commands.Definitions.CustomerKind.Create
{
    public class CreateCustomerKindHandler : IRequestHandler<CreateCustomerKindRequest, CreateCustomerKindResponse>
    {
        readonly ICustomerKindWriteRepository _customerKindWriteRepository;
        readonly IMapper _mapper;
        public CreateCustomerKindHandler(ICustomerKindWriteRepository customerKindWriteRepository, IMapper mapper)
        {
            _customerKindWriteRepository = customerKindWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerKindResponse> Handle(CreateCustomerKindRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<T.CustomerKind>(request);

            customer = await _customerKindWriteRepository.AddAsync(customer);
            await _customerKindWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerKindResponse>(customer);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;


namespace GCrm.Application.Features.Commands.Definitions.CustomerType.Update
{
    public class UpdateCustomerTypeHandler : IRequestHandler<UpdateCustomerTypeRequest, UpdateCustomerTypeResponse>
    {
        readonly ICustomerTypeWriteRepository _customerTypeWriteRepository;
        readonly ICustomerTypeReadRepository _customerTypeReadRepository;
        readonly IMapper _mapper;
        public UpdateCustomerTypeHandler(ICustomerTypeWriteRepository customerTypeWriteRepository, ICustomerTypeReadRepository customerTypeReadRepository, IMapper mapper)
        {
            _customerTypeReadRepository = customerTypeReadRepository;
            _customerTypeWriteRepository = customerTypeWriteRepository;
            _mapper = mapper;
        }
        public async Task<UpdateCustomerTypeResponse> Handle(UpdateCustomerTypeRequest request, CancellationToken cancellationToken)
        {
            T.CustomerType customerType = await _customerTypeReadRepository.GetByIdAsync(request.Id);
            customerType = _mapper.Map(request, customerType);
            await _customerTypeWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerTypeResponse>(customerType);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerContact.Update
{
    public class UpdateCustomerContactHandler : IRequestHandler<UpdateCustomerContactRequest, UpdateCustomerContactResponse>
    {
        readonly ICustomerContactWriteRepository _customerContactWriteRepository;
        readonly ICustomerContactReadRepository _customerContactReadRepository;
        readonly ICustomerWriteRepository _customertWriteRepository;
        readonly ICustomerReadRepository _customerReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerContactHandler(ICustomerContactWriteRepository customerContactWriteRepository, ICustomerContactReadRepository customerContactReadRepository, IMapper mapper, ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customertWriteRepository)
        {
            _customerContactWriteRepository = customerContactWriteRepository;
            _customerContactReadRepository = customerContactReadRepository;
            _customerReadRepository = customerReadRepository;
            _mapper = mapper;
            _customertWriteRepository = customertWriteRepository;
        }

        public async Task<UpdateCustomerContactResponse> Handle(UpdateCustomerContactRequest request, CancellationToken cancellationToken)
        {
            var customerContact = await _customerContactReadRepository.GetByIdAsync(request.Id);
            customerContact = _mapper.Map(request, customerContact);

            if (!string.IsNullOrEmpty(request.CustomerId))
            {
                var customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);
                customer.DefaultContactId = customerContact.Id;
                _customertWriteRepository.Update(customer);
            }
            if (string.IsNullOrEmpty(request.BirthDate.ToString()))
            {
                customerContact.BirthDate = null;
            }


            await _customerContactWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerContactResponse>(customerContact);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerOffer.Create
{
    public class CreateCustomerOfferHandler : IRequestHandler<CreateCustomerOfferRequest, CreateCustomerOfferResponse>
    {

        readonly ICustomerOfferWriteRepository _customerOfferWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerOfferHandler(ICustomerOfferWriteRepository customerOfferWriteRepository, IMapper mapper)
        {

            _customerOfferWriteRepository = customerOfferWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerOfferResponse> Handle(CreateCustomerOfferRequest request, CancellationToken cancellationToken)
        {
            var customerOffer = _mapper.Map<T.CustomerManagement.Customers.CustomerOffer>(request);

            await _customerOfferWriteRepository.AddAsync(customerOffer);
            await _customerOfferWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerOfferResponse>(customerOffer);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

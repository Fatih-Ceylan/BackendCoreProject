using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerOffer.Update
{
    public class UpdateCustomerOfferHandler : IRequestHandler<UpdateCustomerOfferRequest, UpdateCustomerOfferResponse>
    {
        readonly ICustomerOfferWriteRepository _customerOfferWriteRepository;
        readonly ICustomerOfferReadRepository _customerOfferReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerOfferHandler(ICustomerOfferWriteRepository customerOfferWriteRepository, ICustomerOfferReadRepository customerOfferReadRepository, IMapper mapper)
        {
            _customerOfferWriteRepository = customerOfferWriteRepository;
            _customerOfferReadRepository = customerOfferReadRepository;
            _mapper = mapper;


        }
        public async Task<UpdateCustomerOfferResponse> Handle(UpdateCustomerOfferRequest request, CancellationToken cancellationToken)
        {
            var customeroffer = await _customerOfferReadRepository.GetByIdAsync(request.Id);
            customeroffer = _mapper.Map(request, customeroffer);
            await _customerOfferWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerOfferResponse>(customeroffer);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;

        }
    }
}

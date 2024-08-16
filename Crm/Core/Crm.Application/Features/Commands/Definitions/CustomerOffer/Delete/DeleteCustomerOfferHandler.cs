using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerOffer.Delete
{
    public class DeleteCustomerOfferHandler : IRequestHandler<DeleteCustomerOfferRequest, DeleteCustomerOfferResponse>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;

        public DeleteCustomerOfferHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<DeleteCustomerOfferResponse> Handle(DeleteCustomerOfferRequest request, CancellationToken cancellationToken)
        {
            await _customerWriteRepository.SoftDeleteAsync(request.Id);
            await _customerWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}

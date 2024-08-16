using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.SpecialOffer.Delete
{
    public class DeleteSpecialOfferHandler : IRequestHandler<DeleteSpecialOfferRequest, DeleteSpecialOfferResponse>
    {
        readonly ISpecialOfferWriteRepository _specialOfferWriteRepository;

        public DeleteSpecialOfferHandler(ISpecialOfferWriteRepository specialOfferWriteRepository)
        {
            _specialOfferWriteRepository = specialOfferWriteRepository;
        }

        public async Task<DeleteSpecialOfferResponse> Handle(DeleteSpecialOfferRequest request, CancellationToken cancellationToken)
        {
            await _specialOfferWriteRepository.SoftDeleteAsync(request.Id);
            await _specialOfferWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}

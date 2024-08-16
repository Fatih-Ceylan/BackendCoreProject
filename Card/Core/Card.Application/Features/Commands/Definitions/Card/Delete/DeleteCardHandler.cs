using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.Card.Delete
{
    public class DeleteCardHandler : IRequestHandler<DeleteCardRequest, DeleteCardResponse>
    {
        readonly ICardWriteRepository _cardWriteRepository;

        public DeleteCardHandler(ICardWriteRepository cardWriteRepository)
        {
            _cardWriteRepository = cardWriteRepository;
        }

        public async Task<DeleteCardResponse> Handle(DeleteCardRequest request, CancellationToken cancellationToken)
        {
            await _cardWriteRepository.SoftDeleteAsync(request.Id);
            await _cardWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}

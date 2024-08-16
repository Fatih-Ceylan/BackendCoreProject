using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.Iban.Delete
{
    public class DeleteIbanHandler : IRequestHandler<DeleteIbanRequest, DeleteIbanResponse>
    {
        readonly IIbanWriteRepository _ibanWriteRepository;

        public DeleteIbanHandler(IIbanWriteRepository ibanWriteRepository)
        {
            _ibanWriteRepository = ibanWriteRepository;
        }

        public async Task<DeleteIbanResponse> Handle(DeleteIbanRequest request, CancellationToken cancellationToken)
        {
            await _ibanWriteRepository.SoftDeleteAsync(request.Id);
            await _ibanWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}

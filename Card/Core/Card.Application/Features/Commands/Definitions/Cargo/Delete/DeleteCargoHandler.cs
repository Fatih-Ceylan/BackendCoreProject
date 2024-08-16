using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.Cargo.Delete
{
    public class DeleteCargoHandler : IRequestHandler<DeleteCargoRequest, DeleteCargoResponse>
    {
        readonly ICargoWriteRepository _cargoWriteRepository;

        public DeleteCargoHandler(ICargoWriteRepository cargoWriteRepository)
        {
            _cargoWriteRepository = cargoWriteRepository;
        }

        public async Task<DeleteCargoResponse> Handle(DeleteCargoRequest request, CancellationToken cancellationToken)
        {
            await _cargoWriteRepository.SoftDeleteAsync(request.Id);
            await _cargoWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}

using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Voyage.Delete
{
    public class DeleteVoyageHandler : IRequestHandler<DeleteVoyageRequest, DeleteVoyageResponse>
    {
        readonly IVoyageWriteRepository _voyageWriteRepository;

        public DeleteVoyageHandler(IVoyageWriteRepository voyageWriteRepository)
        {
            _voyageWriteRepository = voyageWriteRepository;
        }

        public async Task<DeleteVoyageResponse> Handle(DeleteVoyageRequest request, CancellationToken cancellationToken)
        {
            await _voyageWriteRepository.SoftDeleteAsync(request.Id);
            await _voyageWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
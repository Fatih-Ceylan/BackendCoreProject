using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.Location.Delete
{
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationRequest, DeleteLocationResponse>
    {
        readonly ILocationWriteRepository _locationWriteRepository;
        public DeleteLocationHandler(ILocationWriteRepository locationWriteRepository)
        {
            _locationWriteRepository = locationWriteRepository;
        }

        public async Task<DeleteLocationResponse> Handle(DeleteLocationRequest request, CancellationToken cancellationToken)
        {
            await _locationWriteRepository.SoftDeleteAsync(request.Id);
            await _locationWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}

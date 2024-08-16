using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.GModule.Delete
{
    public class DeleteGModuleHandler : IRequestHandler<DeleteGModuleRequest, DeleteGModuleResponse>
    {
        readonly IGModuleWriteRepository _gmoduleWriteRepository;

        public DeleteGModuleHandler(IGModuleWriteRepository gmoduleWriteRepository)
        {
            _gmoduleWriteRepository = gmoduleWriteRepository;
        }

        public async Task<DeleteGModuleResponse> Handle(DeleteGModuleRequest request, CancellationToken cancellationToken)
        {
            await _gmoduleWriteRepository.SoftDeleteAsync(request.Id);
            await _gmoduleWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}

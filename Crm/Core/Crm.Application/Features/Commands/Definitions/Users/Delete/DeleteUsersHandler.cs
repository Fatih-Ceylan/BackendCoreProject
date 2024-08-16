using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.Users.Delete
{
    public class DeleteUsersHandler : IRequestHandler<DeleteUsersRequest, DeleteUsersResponse>
    {
        readonly IUsersWriteRepository _usersWriteRepository;

        public DeleteUsersHandler(IUsersWriteRepository usersWriteRepository)
        {
            _usersWriteRepository = usersWriteRepository;
        }

        public async Task<DeleteUsersResponse> Handle(DeleteUsersRequest request, CancellationToken cancellationToken)
        {
            await _usersWriteRepository.SoftDeleteAsync(request.Id);
            await _usersWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}

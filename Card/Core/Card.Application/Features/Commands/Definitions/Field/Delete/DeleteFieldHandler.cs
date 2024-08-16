using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.Field.Delete
{
    public class DeleteFieldHandler : IRequestHandler<DeleteFieldRequest, DeleteFieldResponse>
    {
        readonly IFieldWriteRepository _fieldWriteRepository;

        public DeleteFieldHandler(IFieldWriteRepository fieldWriteRepository)
        {
            _fieldWriteRepository = fieldWriteRepository;
        }

        public async Task<DeleteFieldResponse> Handle(DeleteFieldRequest request, CancellationToken cancellationToken)
        {
            await _fieldWriteRepository.SoftDeleteAsync(request.Id);
            await _fieldWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}

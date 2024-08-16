using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.Announcement.Delete
{
    public class DeleteAnnouncementHandler : IRequestHandler<DeleteAnnouncementRequest, DeleteAnnouncementResponse>
    {
        readonly IAnnouncementWriteRepository _announcementWriteRepository;
        public DeleteAnnouncementHandler(IAnnouncementWriteRepository announcementWriteRepository)
        {
            _announcementWriteRepository = announcementWriteRepository;
        }

        public async Task<DeleteAnnouncementResponse> Handle(DeleteAnnouncementRequest request, CancellationToken cancellationToken)
        {
            await _announcementWriteRepository.SoftDeleteAsync(request.Id);
            await _announcementWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}

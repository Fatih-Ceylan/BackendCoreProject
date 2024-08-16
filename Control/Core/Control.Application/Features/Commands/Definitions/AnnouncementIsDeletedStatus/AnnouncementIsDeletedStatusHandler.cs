using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.AnnouncmentIsDeletedStatus
{
    public class AnnouncementIsDeletedStatusHandler : IRequestHandler<AnnouncementIsDeletedStatusRequest, AnnouncementIsDeletedStatusResponse>
    {
        readonly IAnnouncementWriteRepository _announcmentWriteRepository;
        readonly IAnnouncementReadRepository _announcmentReadRepository;
        readonly IMapper _mapper;

        public AnnouncementIsDeletedStatusHandler(IAnnouncementWriteRepository announcmentWriteRepository, IAnnouncementReadRepository announcmentReadRepository, IMapper mapper)
        {
            _announcmentWriteRepository = announcmentWriteRepository;

            _announcmentReadRepository = announcmentReadRepository;
            _mapper = mapper;
        }

        public async Task<AnnouncementIsDeletedStatusResponse> Handle(AnnouncementIsDeletedStatusRequest request, CancellationToken cancellationToken)
        {
            var announcmentIsDeleted = await _announcmentReadRepository.GetByIdAsync(request.Id);
            announcmentIsDeleted.IsDeleted = request.IsDeleted;
            _mapper.Map(request.IsDeleted, announcmentIsDeleted.IsDeleted);
            await _announcmentWriteRepository.SaveAsync();
            var updatedResponse = new AnnouncementIsDeletedStatusResponse
            {
                Id = announcmentIsDeleted.Id.ToString(),
                IsDeleted = announcmentIsDeleted.IsDeleted,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };


            return updatedResponse;
        }
    }
}
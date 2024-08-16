using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.SocialMediaUrl.Delete
{
    public class DeleteSocialMediaUrlHandler : IRequestHandler<DeleteSocialMediaUrlRequest, DeleteSocialMediaUrlResponse>
    {
        readonly ISocialMediaUrlWriteRepository _socialMediaUrlWriteRepository;

        public DeleteSocialMediaUrlHandler(ISocialMediaUrlWriteRepository socialMediaUrlWriteRepository)
        {
            _socialMediaUrlWriteRepository = socialMediaUrlWriteRepository;
        }

        public async Task<DeleteSocialMediaUrlResponse> Handle(DeleteSocialMediaUrlRequest request, CancellationToken cancellationToken)
        {
            await _socialMediaUrlWriteRepository.SoftDeleteAsync(request.Id);
            await _socialMediaUrlWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}

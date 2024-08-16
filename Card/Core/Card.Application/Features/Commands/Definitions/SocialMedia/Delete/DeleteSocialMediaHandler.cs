using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.SocialMedia.Delete
{
    public class DeleteSocialMediaHandler : IRequestHandler<DeleteSocialMediaRequest, DeleteSocialMediaResponse>
    {
        readonly ISocialMediaWriteRepository _socialMediaWriteRepository;

        public DeleteSocialMediaHandler(ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _socialMediaWriteRepository = socialMediaWriteRepository;
        }

        public async Task<DeleteSocialMediaResponse> Handle(DeleteSocialMediaRequest request, CancellationToken cancellationToken)
        {
            await _socialMediaWriteRepository.SoftDeleteAsync(request.Id);
            await _socialMediaWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}

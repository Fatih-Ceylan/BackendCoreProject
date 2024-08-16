using AutoMapper;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.SocialMedia.Create
{
    public class CreateSocialMediaHandler : IRequestHandler<CreateSocialMediaRequest, CreateSocialMediaResponse>
    {
        readonly ISocialMediaWriteRepository _socialMediaWriteRepository;
        readonly IMapper _mapper;

        public CreateSocialMediaHandler(ISocialMediaWriteRepository socialMediaWriteRepository, IMapper mapper)
        {
            _socialMediaWriteRepository = socialMediaWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateSocialMediaResponse> Handle(CreateSocialMediaRequest request, CancellationToken cancellationToken)
        {
            T.SocialMedia socialMedia = _mapper.Map<T.SocialMedia>(request);

            await _socialMediaWriteRepository.AddAsync(socialMedia);
            await _socialMediaWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateSocialMediaResponse>(socialMedia);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

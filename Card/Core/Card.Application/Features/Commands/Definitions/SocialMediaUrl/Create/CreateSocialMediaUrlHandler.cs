using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.SocialMediaUrl.Create
{
    public class CreateSocialMediaUrlHandler : IRequestHandler<CreateSocialMediaUrlRequest, CreateSocialMediaUrlResponse>
    {
        readonly ISocialMediaUrlWriteRepository _socialMediaUrlWriteRepository;
        readonly IMapper _mapper;
        readonly ISocialMediaReadRepository _socialMediaReadRepository;

        public CreateSocialMediaUrlHandler(ISocialMediaUrlWriteRepository socialMediaUrlWriteRepository, IMapper mapper, ISocialMediaReadRepository socialMediaReadRepository)
        {
            _socialMediaUrlWriteRepository = socialMediaUrlWriteRepository;
            _mapper = mapper;
            _socialMediaReadRepository = socialMediaReadRepository;
        }

        public async Task<CreateSocialMediaUrlResponse> Handle(CreateSocialMediaUrlRequest request, CancellationToken cancellationToken)
        {
            var socialMediaUrl = _mapper.Map<T.SocialMediaUrl>(request);

            var socialMediaName = await _socialMediaReadRepository.GetByIdAsync(request.SocialMediaId);

            socialMediaUrl = await _socialMediaUrlWriteRepository.AddAsync(socialMediaUrl);

            await _socialMediaUrlWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateSocialMediaUrlResponse>(socialMediaUrl);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();
            createdResponse.SocialMediaName = socialMediaName.Name != null ? socialMediaName.Name : null;
            createdResponse.UrlPath = request.UrlPath;

            return createdResponse;
        }
    }
}

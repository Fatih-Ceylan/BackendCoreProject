using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.SocialMediaUrl.Update
{
    public class UpdateSocialMediaUrlHandler : IRequestHandler<UpdateSocialMediaUrlRequest, UpdateSocialMediaUrlResponse>
    {
        readonly ISocialMediaUrlWriteRepository _socialMediaUrlWriteRepository;
        readonly ISocialMediaUrlReadRepository _socialMediaUrlReadRepository;
        readonly IMapper _mapper;

        public UpdateSocialMediaUrlHandler(ISocialMediaUrlWriteRepository socialMediaUrlWriteRepository, ISocialMediaUrlReadRepository socialMediaUrlReadRepository, IMapper mapper)
        {
            _socialMediaUrlWriteRepository = socialMediaUrlWriteRepository;
            _socialMediaUrlReadRepository = socialMediaUrlReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSocialMediaUrlResponse> Handle(UpdateSocialMediaUrlRequest request, CancellationToken cancellationToken)
        {
            T.SocialMediaUrl socialMediaUrl = await _socialMediaUrlReadRepository.GetByIdAsync(request.Id);
            socialMediaUrl = _mapper.Map(request, socialMediaUrl);
            await _socialMediaUrlWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateSocialMediaUrlResponse>(socialMediaUrl);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

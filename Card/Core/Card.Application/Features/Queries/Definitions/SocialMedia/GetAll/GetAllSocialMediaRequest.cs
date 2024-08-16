using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.SocialMedia.GetAll
{
    public class GetAllSocialMediaRequest : Pagination, IRequest<GetAllSocialMediaResponse>
    { 
    }
}

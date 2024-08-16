using GControl.Application.Repositories.ReadRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Queries.Definitions.UserMainInfo.GetCurrentUserInfo
{
    public class GetCurrentUserInfoHandler : IRequestHandler<GetCurrentUserInfoRequest, GetCurrentUserInfoResponse>
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IUserMainInfoReadRepository _userMainInfoReadRepository;

        public GetCurrentUserInfoHandler(IHttpContextAccessor httpContextAccessor, IUserMainInfoReadRepository userMainInfoReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userMainInfoReadRepository = userMainInfoReadRepository;
        }

        public async Task<GetCurrentUserInfoResponse> Handle(GetCurrentUserInfoRequest request, CancellationToken cancellationToken)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;

            if (currentUser.Identity.IsAuthenticated == false)
                throw new Exception("User is not Authenticated");

            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            T.UserMainInfo? userMainInfo = new();
            userMainInfo = _userMainInfoReadRepository.GetWhere(umi => umi.AppUserId == Guid.Parse(currentUserId)).FirstOrDefault();

            GetCurrentUserInfoResponse response = new();

            if (userMainInfo == null) {
                response.AppUserId = currentUserId.ToString();
                response.IsCompleted = false;
            }
            else
            {
                response.AppUserId = userMainInfo.AppUserId.ToString();
                response.IsCompleted = userMainInfo.IsCompleted;
            }

            return response;
        }
    }
}
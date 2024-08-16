using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.UserMainInfo.Create
{
    public class CreateUserMainInfoHandler : IRequestHandler<CreateUserMainInfoRequest, CreateUserMainInfoResponse>
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IUserMainInfoWriteRepository _userMainInfoWriteRepository;
        readonly IUserMainInfoReadRepository _userMainInfoReadRepository;

        public CreateUserMainInfoHandler(IHttpContextAccessor httpContextAccessor, IUserMainInfoWriteRepository userMainInfoWriteRepository, IUserMainInfoReadRepository userMainInfoReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userMainInfoWriteRepository = userMainInfoWriteRepository;
            _userMainInfoReadRepository = userMainInfoReadRepository;
        }

        public async Task<CreateUserMainInfoResponse> Handle(CreateUserMainInfoRequest request, CancellationToken cancellationToken)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;

            if (currentUser.Identity.IsAuthenticated == false)
                throw new Exception("User is not Authenticated");

            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userMainInfos = _userMainInfoReadRepository.GetAllDeletedStatusDesc(false, false);

            // Mevcut kullanıcı kimliği ile eşleşen kayıtları filtreleyin
            var userMainInfoWithCurrentUser = userMainInfos.FirstOrDefault(info => info.AppUserId == Guid.Parse(currentUserId));

            // Eşleşen bir kayıt varsa, işlem yapmayın
            if (userMainInfoWithCurrentUser != null)
                return new CreateUserMainInfoResponse
                {
                    Message = "UserMainInfo already exists for the current user"
                };

            // Eşleşen bir kayıt yoksa, yeni bir kayıt oluşturun
            var userMainInfo = new T.UserMainInfo
            {
                AppUserId = Guid.Parse(currentUserId),
                IsCompleted = true
            };

            await _userMainInfoWriteRepository.AddAsync(userMainInfo);
            await _userMainInfoWriteRepository.SaveAsync();

            return new CreateUserMainInfoResponse
            {
                Message = "UserMainInfo save successful"
            };
        }
    }
}


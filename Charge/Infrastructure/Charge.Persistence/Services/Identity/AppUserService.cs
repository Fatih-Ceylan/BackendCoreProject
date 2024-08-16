using GCharge.Application.Abstractions.Identity;
using GCharge.Application.DTOs.Identity.AppUser;
using GCharge.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Utilities.Core.UtilityApplication.Exceptions;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCharge.Persistence.Services.Identity
{
    public class AppUserService : IAppUserService
    {
        readonly UserManager<AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO request)
        {
            var id = Guid.NewGuid().ToString();

            var appUser = new AppUser
            {
                Id = id,
                FullName = request.FullName,
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);

            CreateUserResponseDTO response = new() { Succeed = result.Succeeded };
            if (!result.Succeeded)
            {
                response.Message = string.Empty;
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description} \n ";
                }
                return response;
            }
            else
            {
                response.Id = id;
                response.FullName = request.FullName;
                response.Email = request.Email;
                response.PhoneNumber = request.PhoneNumber;
                response.Message = "User Created Successfully";

                await _userManager.AddToRoleAsync(appUser, "MobileUser");
            }
            return response;
        }


        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUserEcxeption();
            }
        }

        public async Task<UpdateUserResponseDTO> UpdateAsync(UpdateUserRequestDTO request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user != null)
            {
                user.ProfileImagePath = request.ProfileImagePath != null ? request.ProfileImagePath : user.ProfileImagePath;
                user.FullName = request.FullName;
                user.UserName = request.UserName;
                user.Email = request.Email;

                IdentityResult result = await _userManager.UpdateAsync(user);

                var response = SetUpdateResponse(result, "Updated");
                if (result.Succeeded)
                {
                    response.ProfileImagePath = request.ProfileImagePath;
                    response.FullName = request.FullName;
                    response.UserName = request.UserName;
                    response.Email = request.Email;
                }

                return response;
            }
            else
            {
                throw new NotFoundUserEcxeption();
            }
        }

        public async Task<DeleteUserResponseDTO> SoftDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                IdentityResult result = await _userManager.UpdateAsync(user);

                var updateResponse = SetUpdateResponse(result, "Deleted");

                return new()
                {
                    Succeed = updateResponse.Succeed,
                    Message = updateResponse.Message,
                };
            }
            else
            {
                throw new NotFoundUserEcxeption();
            }
        }

        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                return new()
                {
                    Id = user.Id,
                    ProfileImagePath = user.ProfileImagePath,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                };
            }
            else
            {
                throw new NotFoundUserEcxeption();
            }
        }

        public UserListDTO GetAllDeletedStatus(Pagination paginationRequest)
        {
            var query = _userManager.Users
                        .Where(u => u.IsDeleted == paginationRequest.IsDeleted);

            var users = paginationRequest.DoPagination ? query.Skip(paginationRequest.Page * paginationRequest.Size)
                                                       .Take(paginationRequest.Size)
                                                       .ToList()
                                                : query.ToList();

            var result = (from u in users
                          select new UserDTO
                          {
                              Id = u.Id,
                              ProfileImagePath = u.ProfileImagePath,
                              FullName = u.FullName,
                              UserName = u.UserName,
                              Email = u.Email,
                          }).ToList();

            return new()
            {
                TotalCount = query.Count(),
                AppUsers = result
            };
        }

        private UpdateUserResponseDTO SetUpdateResponse(IdentityResult result, string setType)
        {
            UpdateUserResponseDTO response = new() { Succeed = result.Succeeded };
            if (!result.Succeeded)
            {
                response.Message = string.Empty;
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description} \n ";
                }
            }
            else
            {
                response.Message = $"User {setType} Successfully";
            }

            return response;
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser appUser = await _userManager.FindByIdAsync(userId);
            if (appUser != null)
            {
                byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                resetToken = Encoding.UTF8.GetString(tokenBytes);
                IdentityResult result = await _userManager.ResetPasswordAsync(appUser, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(appUser);
                else
                    throw new Exception("Password change failed!");
            }
            else
                throw new NotFoundUserEcxeption();
        }


    }
}
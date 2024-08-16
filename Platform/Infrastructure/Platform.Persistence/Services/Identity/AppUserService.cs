using Microsoft.AspNetCore.Identity;
using Platform.Application.Abstractions.Services.Identity;
using Platform.Application.DTOs.Identity.AppUser;
using Platform.Domain.Entities.Identity;
using Utilities.Core.UtilityApplication.Exceptions;
using Utilities.Core.UtilityApplication.RequestParameters;
using Utilities.Core.UtilityApplication.VMs;

namespace Platform.Persistence.Services.Identity
{
    public class AppUserService : IAppUserService
    {
        readonly UserManager<AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                ProfileImagePath = model.ProfileImagePath,
            }, model.Password);

            CreateUserResponseDTO response = new() { Succeed = result.Succeeded };
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
                response.Message = "User Created Successfully";
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

        public async Task<UpdateUserResponseDTO> UpdateAsync(UpdateUserRequestDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.FullName = model.FullName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.IsDeleted = model.IsDeleted;
                user.ProfileImagePath = model.ProfileImagePath;

                IdentityResult result = await _userManager.UpdateAsync(user);

                return SetUpdateResponse(result, "Updated");
            }
            else
            {
                throw new NotFoundUserEcxeption();
            }
        }

        public async Task<UpdateUserResponseDTO> SoftDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                IdentityResult result = await _userManager.UpdateAsync(user);

                return SetUpdateResponse(result, "Deleted");
            }
            else
            {
                throw new NotFoundUserEcxeption();
            }
        }

        public async Task<UserResponseDTO> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                AppUserVM appUserVM = new();

                appUserVM.Id = id;
                appUserVM.FullName = user.FullName;
                appUserVM.UserName = user.UserName;
                appUserVM.Email = user.Email;
                appUserVM.ProfileImagePath = user.ProfileImagePath;

                return new()
                {
                    User = appUserVM,
                };
            }
            else
            {
                throw new NotFoundUserEcxeption();
            }
        }

        public UserListResponseDTO GetAllDeletedStatus(Pagination pagination)
        {
            var totalCount = _userManager.Users
                        .Where(u => u.IsDeleted == pagination.IsDeleted).Count();

            var users = pagination.DoPagination ? _userManager.Users
                                                 .Where(u => u.IsDeleted == pagination.IsDeleted)
                                                 .Skip(pagination.Page * pagination.Size)
                                                 .Take(pagination.Size)
                                                 .ToList()
                                                : _userManager.Users
                                                  .Where(u => u.IsDeleted == pagination.IsDeleted)
                                                  .ToList();
            List<AppUserVM> responseList = new();
            AppUserVM response;

            foreach (var user in users)
            {
                response = new();
                response.Id = user.Id;
                response.FullName = user.FullName;
                response.UserName = user.UserName;
                response.Email = user.Email;
                response.ProfileImagePath = user.ProfileImagePath;
                responseList.Add(response);
            }

            return new()
            {
                TotalCount = totalCount,
                Users = responseList
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
    }
}
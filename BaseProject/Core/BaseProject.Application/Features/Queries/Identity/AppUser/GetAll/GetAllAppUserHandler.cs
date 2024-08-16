using AutoMapper;
using BaseProject.Application.Abstractions.Services.Identity;
using BaseProject.Application.VMs.Definitions.AppUser;
using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Identity.AppUser.GetAll
{
    public class GetAllAppUserHandler : IRequestHandler<GetAllAppUserRequest, GetAllAppUserResponse>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;

        public GetAllAppUserHandler(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public async Task<GetAllAppUserResponse> Handle(GetAllAppUserRequest request, CancellationToken cancellationToken)
        {
            Pagination paginationRequest = new();
            paginationRequest.Page = request.Page;
            paginationRequest.Size = request.Size;
            paginationRequest.IsDeleted = request.IsDeleted;
            paginationRequest.DoPagination = request.DoPagination;

            var appUsersDto = _appUserService.GetAllDeletedStatus(paginationRequest);
            
            var appUsersVM = _mapper.Map<List<AppUserVM>>(appUsersDto.AppUsers);

            return new()
            {
                TotalCount = appUsersDto.TotalCount,
                AppUsers = appUsersVM
            };
        }
    }
}
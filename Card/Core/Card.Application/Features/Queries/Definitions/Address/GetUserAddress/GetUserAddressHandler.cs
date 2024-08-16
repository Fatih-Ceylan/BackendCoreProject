using BaseProject.Application.Abstractions.Services.Identity;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.CurrentUser;

namespace Card.Application.Features.Queries.Definitions.Address.GetUserAddress
{
    public class GetUserAddressHandler : IRequestHandler<GetUserAddressRequest, GetUserAddressResponse>
    {
        readonly ICurrentUserService _currentUserService;
        readonly IAppUserService _appUserService;
        readonly IBranchReadRepository _branchReadRepository;
        readonly ICompanyReadRepository _companyReadRepository;

        public GetUserAddressHandler(ICurrentUserService currentUserService, IAppUserService appUserService, IBranchReadRepository branchReadRepository, ICompanyReadRepository companyReadRepository)
        {
            _currentUserService = currentUserService;
            _appUserService = appUserService;
            _branchReadRepository = branchReadRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<GetUserAddressResponse> Handle(GetUserAddressRequest request, CancellationToken cancellationToken)
        {
            var user = await _currentUserService.GetCurrentUser();

            var userInfo = await _appUserService.GetByIdAsync(user.Id.ToString());

            var branch = await _branchReadRepository.GetByIdAsync(userInfo.BranchId.ToString());

            var company= await _companyReadRepository.GetByIdAsync(userInfo.CompanyId.ToString());
             
            GetUserAddressResponse response = new();

            //response.DistrictId = company.DistrictId.ToString();
            response.Id = company.Id.ToString();
            response.PhoneNumber = company.PhoneNumber;
            response.FullName = userInfo.FullName;
            //response.FullAddress = company.FullAddress;
            //response.CityId = company.CityId.ToString(); 
            response.BaseProjectBranchId=branch.Id.ToString();
            response.BaseProjectBranchName=branch.Name;
            response.BaseProjectCompanyId=company.Id.ToString();
            response.BaseProjectCompanyName=company.Name;

            return response;
        }
    }
}

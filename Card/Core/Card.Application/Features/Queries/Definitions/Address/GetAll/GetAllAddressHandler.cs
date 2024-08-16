using BaseProject.Application.Abstractions.Services.Definitions;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Address.GetAll
{
    public class GetAllAddressHandler : IRequestHandler<GetAllAddressRequest, GetAllAddressResponse>
    {
        readonly IBranchService _branchService;

        public GetAllAddressHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<GetAllAddressResponse> Handle(GetAllAddressRequest request, CancellationToken cancellationToken)
        {
            //if (request.CompanyId == "SelectAll")
            //{
            //    request.CompanyId = null;
            //}
            //if (request.BranchId == "SelectAll")
            //{
            //    request.BranchId = null;
            //}
            var branches = await _branchService.GetAllActiveBranchesWithIds(request.CompanyId, request.BranchId);

            var addresses = branches.Select(b => new AddressVM
            {
                AddressLine = b.FullAddress,
                CompanyId = b.CompanyId?.ToString(),
                BranchName = b.Name,
                BranchId = b.Id.ToString(),
                CompanyName = b.CompanyName,
                CityId = b.CityId?.ToString(),
                CountryId = b.CountryId?.ToString(),
                DistrictId = b.DistrictId?.ToString(),
                CityName = b.CityName,
                CountryName = b.CountryName,
                DistrictName = b.DistrictName,

            }).ToList();

            var totalCount = addresses.Count;
            var response = addresses.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllAddressResponse
            {
                TotalCount = totalCount,
                Addresses = response
            };
        }
    }
}

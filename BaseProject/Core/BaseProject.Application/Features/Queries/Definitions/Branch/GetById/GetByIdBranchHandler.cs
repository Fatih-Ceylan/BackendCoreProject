using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.Branch;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Branch.GetById
{
    public class GetByIdBranchHandler : IRequestHandler<GetByIdBranchRequest, GetByIdBranchResponse>
    {
        readonly IBranchReadRepository _branchReadRepository;

        public GetByIdBranchHandler(IBranchReadRepository branchReadRepository)
        {
            _branchReadRepository = branchReadRepository;
        }

        public async Task<GetByIdBranchResponse> Handle(GetByIdBranchRequest request, CancellationToken cancellationToken)
        {
            var branch = _branchReadRepository
                        .GetWhere(b => b.Id == Guid.Parse(request.Id))
                        .Select(b => new BranchVM
                        {
                            Id = b.Id.ToString(),
                            CompanyId = b.CompanyId.ToString(),
                            CompanyName = b.Company.Name,
                            Code = b.Code,
                            Name = b.Name,
                            AuthorizedFullName = b.AuthorizedFullName,
                            FullAddress = b.FullAddress,
                            PostalCode = b.PostalCode,
                            PhoneNumber = b.PhoneNumber,
                            Email = b.Email,
                            CountryId = b.CountryId,
                            CountryName = b.District != null ? b.District.City.Country.Name : null,
                            CityId = b.CityId,
                            CityName = b.District != null ? b.District.City.Name : null,
                            DistrictId = b.DistrictId,
                            DistrictName = b.District != null ? b.District.Name : null,
                            CreatedDate = b.CreatedDate
                        }).FirstOrDefault();

            return new()
            {
                Branch = branch
            };
        }
    }
}
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.Branch;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Branch.GetAll
{
    public class GetAllBranchHandler : IRequestHandler<GetAllBranchRequest, GetAllBranchResponse>
    {
        readonly IBranchReadRepository _branchReadRepository;

        public GetAllBranchHandler(IBranchReadRepository branchReadRepository)
        {
            _branchReadRepository = branchReadRepository;
        }

        public Task<GetAllBranchResponse> Handle(GetAllBranchRequest request, CancellationToken cancellationToken)
        {
            var query = _branchReadRepository
                        .GetAllDeletedStatusDesc(false, request.IsDeleted)
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
                        });

            if (request.CompanyId != null ) {
                query = query.Where(b => b.CompanyId == request.CompanyId);
            }

            var totalCount = query.Count();
            var branches = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                       .Take(request.Size).ToList()
                                                : query.ToList();

            return Task.FromResult(new GetAllBranchResponse
            {
                TotalCount = totalCount,
                Branches = branches,
            });
        }
    }
}
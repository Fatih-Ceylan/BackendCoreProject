using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.Company;

namespace Platform.Application.Features.Queries.Definitions.Company.GetAll
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyRequest, GetAllCompanyResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;

        public GetAllCompanyHandler(ICompanyReadRepository companyReadRepository)
        {
            _companyReadRepository = companyReadRepository;
        }

        public Task<GetAllCompanyResponse> Handle(GetAllCompanyRequest request, CancellationToken cancellationToken)
        {
            var query = _companyReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
                .Select(c => new CompanyVM
                {
                    Id = c.Id.ToString(),
                    AdminUserEmail = c.AdminUserEmail,
                    AdminUserFullName = c.AdminUserFullName,
                    AuthorizedFullName = c.AuthorizedFullName,
                    BaseDbName = c.BaseDbName,
                    Email = c.Email,
                    FaxNo = c.FaxNo,
                    FullAddress = c.FullAddress,
                    LogoPath = c.LogoPath,
                    MersisNo = c.MersisNo,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    PostalCode = c.PostalCode,
                    SocialSecurityNo = c.SocialSecurityNo,
                    TaxNo = c.TaxNo,
                    TaxOffice = c.TaxOffice,
                    TradeRegisterNo = c.TradeRegisterNo,
                    UrlPath = c.UrlPath,
                    WebAddress = c.WebAddress,
                    District = c.District,
                    City = c.City,
                    Country = c.Country,
                    CreatedDate = c.CreatedDate,
                });

            var totalCount = query.Count();
            var companies = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                        .Take(request.Size).ToList()
                                                 : query.ToList();

            return Task.FromResult(new GetAllCompanyResponse
            {
                TotalCount = totalCount,
                Companies = companies,
            });
        }
    }
}
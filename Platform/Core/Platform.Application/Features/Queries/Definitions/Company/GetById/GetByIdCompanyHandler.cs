using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.Company;

namespace Platform.Application.Features.Queries.Definitions.Company.GetById
{
    public class GetByIdCompanyHandler : IRequestHandler<GetByIdCompanyRequest, GetByIdCompanyResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;

        public GetByIdCompanyHandler(ICompanyReadRepository companyReadRepository)
        {
            _companyReadRepository = companyReadRepository;
        }

        public async Task<GetByIdCompanyResponse> Handle(GetByIdCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = _companyReadRepository
                                   .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
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
                                       CreatedDate = c.CreatedDate
                                   }).FirstOrDefault();


            return new()
            {
                Company = company
            };
        }
    }
}
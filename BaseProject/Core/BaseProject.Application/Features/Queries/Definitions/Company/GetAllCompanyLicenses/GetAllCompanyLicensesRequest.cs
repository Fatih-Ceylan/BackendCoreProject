using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetAllCompanyLicenses
{
    public class GetAllCompanyLicensesRequest : IRequest<GetAllCompanyLicensesResponse>
    {
        public string CompanyId { get; set; }

        public List<string> LicenseIds { get; set; }

    }
}
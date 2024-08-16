using MediatR;

namespace Platform.Application.Features.Queries.Definitions.Company.GetByCompanyIdModulesLicenses
{
    public class GetByCompanyIdModulesLicensesRequest: IRequest<GetByCompanyIdModulesLicensesResponse>
    {
        public string Id { get; set; }
    }
}
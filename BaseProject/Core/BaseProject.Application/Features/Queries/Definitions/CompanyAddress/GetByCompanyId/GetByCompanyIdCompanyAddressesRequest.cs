using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetByCompanyId
{
    public class GetByCompanyIdCompanyAddressesRequest : IRequest<GetByCompanyIdCompanyAddressesResponse>
    {
        public string CompanyId { get; set; }
    }
}
using MediatR;

namespace Platform.Application.Features.Queries.Definitions.Company.GetByUrlPath
{
    public class GetByUrlPathCompanyRequest : IRequest<GetByUrlPathCompanyResponse>
    {
        public string UrlPath { get; set; }
    }
}

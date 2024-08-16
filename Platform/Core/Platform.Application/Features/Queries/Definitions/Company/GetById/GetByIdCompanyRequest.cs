using MediatR;

namespace Platform.Application.Features.Queries.Definitions.Company.GetById
{
    public class GetByIdCompanyRequest : IRequest<GetByIdCompanyResponse>
    {
        public string Id { get; set; }
    }
}

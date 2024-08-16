using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetById
{
    public class GetByIdCompanyRequest : IRequest<GetByIdCompanyResponse>
    {
        public string Id { get; set; }

    }
}
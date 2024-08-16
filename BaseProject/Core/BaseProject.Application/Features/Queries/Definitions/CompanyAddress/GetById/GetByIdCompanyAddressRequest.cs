using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetById
{
    public class GetByIdCompanyAddressRequest : IRequest<GetByIdCompanyAddressResponse>
    {
        public string Id { get; set; }
    }
}

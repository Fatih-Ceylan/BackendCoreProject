using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyContactName.GetById
{
    public  class GetByIdCompanyContactNameRequest :IRequest<GetByIdCompanyContactNameResponse>
    {
        public string Id { get; set; }
    }
}

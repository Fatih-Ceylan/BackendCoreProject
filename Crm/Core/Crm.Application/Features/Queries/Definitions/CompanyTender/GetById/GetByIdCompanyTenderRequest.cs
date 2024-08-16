using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyTender.GetById
{
    public  class GetByIdCompanyTenderRequest : IRequest<GetByIdCompanyTenderResponse>
    {
        public string  Id { get; set; }
    }
}

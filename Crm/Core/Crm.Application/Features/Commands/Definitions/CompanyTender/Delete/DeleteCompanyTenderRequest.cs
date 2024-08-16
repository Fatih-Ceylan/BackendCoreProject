using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyTender.Delete
{
    public  class DeleteCompanyTenderRequest : IRequest<DeleteCompanyTenderResponse>
    {
        public string Id { get; set; }
    }
}

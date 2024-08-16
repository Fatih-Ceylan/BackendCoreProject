using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyContactName.Delete
{
    public  class DeleteCompanyContactNameRequest : IRequest<DeleteCompanyContactNameResponse>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyTender.Update
{
    public  class UpdateCompanyTenderRequest : IRequest<UpdateCompanyTenderResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

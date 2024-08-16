using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyTender.Create
{
    public  class CreateCompanyTenderRequest : IRequest<CreateCompanyTenderResponse>
    {
        public string Name { get; set; }
    }
}

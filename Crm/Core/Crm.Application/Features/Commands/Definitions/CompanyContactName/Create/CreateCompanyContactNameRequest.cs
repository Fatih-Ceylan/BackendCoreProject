using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyContactName.Create
{
    public  class CreateCompanyContactNameRequest : IRequest<CreateCompanyContactNameResponse>
    {
        public string Name { get; set; }
    }
}

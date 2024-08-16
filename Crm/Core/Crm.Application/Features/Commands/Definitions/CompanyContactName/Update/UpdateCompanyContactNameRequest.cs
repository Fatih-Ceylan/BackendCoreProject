using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyContactName.Update
{
    public  class UpdateCompanyContactNameRequest : IRequest<UpdateCompanyContactNameResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

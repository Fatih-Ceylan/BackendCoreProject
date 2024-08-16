using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Delete
{
    public class DeleteCompanyAddressRequest: IRequest<DeleteCompanyAddressResponse>
    {
        public string Id { get; set; }

    }
}
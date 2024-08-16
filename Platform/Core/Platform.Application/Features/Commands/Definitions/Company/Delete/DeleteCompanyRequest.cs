using MediatR;

namespace Platform.Application.Features.Commands.Definitions.Company.Delete
{
    public class DeleteCompanyRequest : IRequest<DeleteCompanyResponse>
    {
        public string Id { get; set; }
    }
}

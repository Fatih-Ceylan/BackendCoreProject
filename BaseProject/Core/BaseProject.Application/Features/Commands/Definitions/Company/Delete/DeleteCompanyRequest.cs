using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.Company.Delete
{
    public class DeleteCompanyRequest : IRequest<DeleteCompanyResponse>
    {
        public string Id { get; set; }
    }
}
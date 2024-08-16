using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSubject.Delete
{
    public class DeleteCustomerSubjectRequest : IRequest<DeleteCustomerSubjectResponse>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Delete
{
    public  class DeleteCustomerActivitySubjectRequest : IRequest<DeleteCustomerActivitySubjectResponse>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSubject.Update
{
    public class UpdateCustomerSubjectRequest : IRequest<UpdateCustomerSubjectResponse>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSubject.Create
{
    public class CreateCustomerSubjectRequest : IRequest<CreateCustomerSubjectResponse>
    {
        public string Name { get; set; }
    }
}

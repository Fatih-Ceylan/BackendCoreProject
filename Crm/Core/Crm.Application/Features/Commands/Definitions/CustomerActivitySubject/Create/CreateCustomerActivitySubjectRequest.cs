using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Create
{
    public  class CreateCustomerActivitySubjectRequest : IRequest<CreateCustomerActivitySubjectResponse>
    {
        public string Name { get; set; }
    }
}

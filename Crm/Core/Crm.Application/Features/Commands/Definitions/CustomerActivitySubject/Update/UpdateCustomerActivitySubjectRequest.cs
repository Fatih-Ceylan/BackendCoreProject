using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Update
{
    public  class UpdateCustomerActivitySubjectRequest : IRequest<UpdateCustomerActivitySubjectResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }
    }
}

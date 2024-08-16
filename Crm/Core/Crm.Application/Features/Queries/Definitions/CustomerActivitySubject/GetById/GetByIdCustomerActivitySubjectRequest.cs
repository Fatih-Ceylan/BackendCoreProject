using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivitySubject.GetById
{
    public  class GetByIdCustomerActivitySubjectRequest : IRequest<GetByIdCustomerActivitySubjectResponse>
    {
        public string Id { get; set; }
    }
}

using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSubject.GetById
{
    public  class GetByIdCustomerSubjectRequest : IRequest<GetByIdCustomerSubjectResponse>
    {
        public string  Id { get; set; }
    }
}

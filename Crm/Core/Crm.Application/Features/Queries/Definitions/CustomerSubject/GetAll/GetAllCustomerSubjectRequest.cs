using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSubject.GetAll
{
    public  class GetAllCustomerSubjectRequest : Pagination, IRequest<GetAllCustomerSubjectResponse>
    {
    }
}

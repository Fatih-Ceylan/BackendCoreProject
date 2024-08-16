using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivitySubject.GetAll
{
    public  class GetAllCustomerActivitySubjectRequest : Pagination, IRequest<GetAllCustomerActivitySubjectResponse>
    {
    }
}

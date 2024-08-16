using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerProject.GetAll
{
    public  class GetAllCustomerProjectRequest : Pagination, IRequest<GetAllCustomerProjectResponse>
    {
    }
}

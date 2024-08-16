using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.Project.GetAll
{
    public  class GetAllProjectRequest : Pagination, IRequest<GetAllProjectResponse>
    {
    }
}

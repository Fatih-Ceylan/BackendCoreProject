using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.ProjectManager.GetAll
{
    public  class GetAllProjectManagerRequest : Pagination, IRequest<GetAllProjectManagerResponse>
    {
    }
}

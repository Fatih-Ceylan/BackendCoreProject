using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace HR.Application.Features.Queries.Definitions.Jobs.JobAdvert.GetAll
{
    public class GetAllJobAdvertRequest : Pagination, IRequest<GetAllJobAdvertResponse>
    {
    }
}

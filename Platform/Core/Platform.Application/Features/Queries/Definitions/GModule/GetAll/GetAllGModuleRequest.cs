using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Features.Queries.Definitions.GModule.GetAll
{
    public class GetAllGModuleRequest : Pagination, IRequest<GetAllGModuleResponse>
    {

    }
}

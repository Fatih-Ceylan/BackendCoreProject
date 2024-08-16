using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Location.GetAll
{
    public class GetAllLocationRequest : Pagination, IRequest<GetAllLocationResponse>
    {
        public string? CompanyId { get; set; }
    }
}

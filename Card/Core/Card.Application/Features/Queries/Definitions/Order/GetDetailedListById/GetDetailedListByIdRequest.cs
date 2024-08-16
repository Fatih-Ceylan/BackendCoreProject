using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListById
{
    public class GetDetailedListByIdRequest : Pagination, IRequest<GetDetailedListByIdResponse>
    {
        public string Id { get; set; } 
    }
}

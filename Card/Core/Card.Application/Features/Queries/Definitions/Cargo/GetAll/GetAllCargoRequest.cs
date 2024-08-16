using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.Cargo.GetAll
{
    public class GetAllCargoRequest : Pagination, IRequest<GetAllCargoResponse>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}

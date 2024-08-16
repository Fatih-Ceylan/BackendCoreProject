using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.Field.GetAll
{
    public class GetAllFieldRequest : Pagination, IRequest<GetAllFieldResponse>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}

using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivity.GetAll
{
    public class GetAllCustomerActivityRequest : Pagination, IRequest<GetAllCustomerActivityResponse>
    {
        public string? CompanyId { get; set; }
        //public string? BranchId { get; set; }
    }
}

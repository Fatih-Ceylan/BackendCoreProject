using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.StaffField.GetAll
{
    public class GetAllStaffFieldRequest : Pagination, IRequest<GetAllStaffFieldResponse>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}

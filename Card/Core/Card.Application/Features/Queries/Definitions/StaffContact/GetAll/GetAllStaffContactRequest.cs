using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetAll
{
    public class GetAllStaffContactRequest : Pagination, IRequest<GetAllStaffContactResponse>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}

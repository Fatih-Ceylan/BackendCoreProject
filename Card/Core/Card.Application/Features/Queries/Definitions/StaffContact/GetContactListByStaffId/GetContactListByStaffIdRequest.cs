using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetContactListByStaffId
{
    public class GetContactListByStaffIdRequest : Pagination, IRequest<GetContactListByStaffIdResponse>
    {
        public string Id { get; set; }
    }
}

using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.ShiftManagement.GetAll
{
    public class GetAllShiftManagementRequest : Pagination, IRequest<GetAllShiftManagementResponse>
    {
        public string? CompanyId { get; set; }
    }
}

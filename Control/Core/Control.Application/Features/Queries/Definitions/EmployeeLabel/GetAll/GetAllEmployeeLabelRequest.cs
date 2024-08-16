using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.GetAll
{
    public class GetAllEmployeeLabelRequest : Pagination, IRequest<GetAllEmployeeLabelResponse>
    {
        //public string BaseProjectCompanyId { get; set; }
        //public string BaseProjectBranchId { get; set; }
    }
}

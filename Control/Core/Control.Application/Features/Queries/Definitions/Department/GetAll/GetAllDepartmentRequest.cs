using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Department.GetAll
{
    public class GetAllDepartmentRequest : Pagination, IRequest<GetAllDepartmentResponse>
    {
        //public string BaseProjectCompanyId { get; set; }
        //public string BaseProjectBranchId { get; set; }
    }
}

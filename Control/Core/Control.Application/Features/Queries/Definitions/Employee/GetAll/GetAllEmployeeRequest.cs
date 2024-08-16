using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Employee.GetAll
{
    public class GetAllEmployeeRequest : Pagination, IRequest<GetAllEmployeeResponse>
    {
        public string? CompanyId { get; set; }
        //public string? BranchId { get; set; }
    }
}

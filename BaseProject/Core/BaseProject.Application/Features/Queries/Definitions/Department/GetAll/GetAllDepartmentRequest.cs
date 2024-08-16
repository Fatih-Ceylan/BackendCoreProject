using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetAll
{
    public class GetAllDepartmentRequest : Pagination, IRequest<GetAllDepartmentResponse>
    {
        public string? BranchId { get; set; }

    }
}
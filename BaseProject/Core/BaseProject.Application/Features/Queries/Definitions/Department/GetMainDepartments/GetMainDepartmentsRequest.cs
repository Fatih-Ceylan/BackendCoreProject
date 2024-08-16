using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetMainDepartments
{
    public class GetMainDepartmentsRequest: IRequest<GetMainDepartmentsResponse>
    {
        public string BranchId { get; set; }

    }
}
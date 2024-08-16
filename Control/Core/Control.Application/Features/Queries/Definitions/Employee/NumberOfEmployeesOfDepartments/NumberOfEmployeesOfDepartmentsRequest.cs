using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Employee.NumberOfEmployeesOfDepartments
{
    public class NumberOfEmployeesOfDepartmentsRequest : Pagination, IRequest<NumberOfEmployeesOfDepartmentsResponse>
    {
    }
}

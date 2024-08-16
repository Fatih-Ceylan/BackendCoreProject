using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.EmployeeType.GetAll
{
    public class GetAllEmployeeTypeRequest : Pagination, IRequest<GetAllEmployeeTypeResponse>
    {
       
    }
}

using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.FilterField
{
    public class FilterFieldRequest : Pagination, IRequest<FilterFieldResponse>
    {
        public string? CompanyId { get; set; }
        public string? FilterField { get; set; } 
        public string? Operator { get; set; }
        public string? SortDirection { get; set; }
    }
}

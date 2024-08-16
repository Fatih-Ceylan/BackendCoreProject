using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.Branch.GetAll
{
    public class GetAllBranchRequest : Pagination, IRequest<GetAllBranchResponse>
    {
        public string? CompanyId { get; set; }
    }
}
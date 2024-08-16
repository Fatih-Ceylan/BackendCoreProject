using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.GetAll
{
    public class GetAllEntryExitManagementRequest : Pagination, IRequest<GetAllEntryExitManagementResponse>
    {
        public string CompanyId { get; set; }
    }
}

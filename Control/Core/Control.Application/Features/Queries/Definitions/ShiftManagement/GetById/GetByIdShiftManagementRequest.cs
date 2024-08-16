using MediatR;

namespace GControl.Application.Features.Queries.Definitions.ShiftManagement.GetById
{
    public class GetByIdShiftManagementRequest : IRequest<GetByIdShiftManagementResponse>
    {
        public string Id { get; set; }
    }
}

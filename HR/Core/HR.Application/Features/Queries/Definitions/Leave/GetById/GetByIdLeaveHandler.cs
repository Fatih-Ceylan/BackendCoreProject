using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.Leave.GetById
{
    public class GetByIdLeaveHandler : IRequestHandler<GetByIdLeaveRequest, GetByIdLeaveResponse>
    {
        public ILeaveReadRepository _leaveReadRepository;

        public GetByIdLeaveHandler(ILeaveReadRepository LeaveReadRepository)
        { _leaveReadRepository = LeaveReadRepository; }

        public async Task<GetByIdLeaveResponse> Handle(GetByIdLeaveRequest request, CancellationToken cancellationToken)
        {
            var Leave = _leaveReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new LeaveVM
                            {
                                Id = c.Id.ToString(),
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                DayCount = c.DayCount,
                                HourCount = c.HourCount,
                                LeaveTypeId = c.LeaveTypeId.ToString(),
                                LeaveTypeName = c.LeaveType != null ? c.LeaveType.Name : null,
                                EmployeeId = c.EmployeeId.ToString(),
                                EmployeeName = c.Employee.FirstName,
                                EmployeeReplacement = c.EmployeeReplacement.ToString(),
                                LeaveStatus = (int)c.LeaveStatus,
                                CreatedDate = c.CreatedDate
                            }).FirstOrDefault();

            return new() { LeaveVM = Leave };
        }
    }
}

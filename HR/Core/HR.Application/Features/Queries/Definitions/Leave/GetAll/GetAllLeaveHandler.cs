using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.Leave.GetAll
{
    public class GetAllLeaveHandler : IRequestHandler<GetAllLeaveRequest, GetAllLeaveResponse>
    {
        public ILeaveReadRepository _LeaveReadRepository;

        public GetAllLeaveHandler(ILeaveReadRepository LeaveReadRepository)
        {
            _LeaveReadRepository = LeaveReadRepository;
        }

        public Task<GetAllLeaveResponse> Handle(GetAllLeaveRequest request, CancellationToken cancellationToken)
        {
            var query = _LeaveReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
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
                   EmployeeReplacement = c.EmployeeReplacement != null ? c.EmployeeReplacement.ToString() : null,
                   LeaveStatus = (int)c.LeaveStatus,
                   LeaveStatusName = c.LeaveStatus.ToString(),
                   CreatedDate = c.CreatedDate
               });
            var totalCount = query.Count();
            var Leaves = request.DoPagination ? query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList() : query.ToList();

            return Task.FromResult(new GetAllLeaveResponse
            {
                TotalCount = totalCount,
                LeaveVMs = Leaves,
            });
        }
    }
}

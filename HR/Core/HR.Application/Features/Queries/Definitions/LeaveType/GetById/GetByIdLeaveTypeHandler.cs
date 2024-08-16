using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.LeaveType.GetById
{
    public class GetByIdLeaveTypeHandler : IRequestHandler<GetByIdLeaveTypeRequest, GetByIdLeaveTypeResponse>
    {
        public ILeaveTypeReadRepository _LeaveTypeReadRepository;

        public GetByIdLeaveTypeHandler(ILeaveTypeReadRepository LeaveTypeReadRepository)
        { _LeaveTypeReadRepository = LeaveTypeReadRepository; }

        public async Task<GetByIdLeaveTypeResponse> Handle(GetByIdLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = _LeaveTypeReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new LeaveTypeVM
                            {
                                Id = c.Id.ToString(),
                                Code = c.Code,
                                Name = c.Name,
                                CreatedDate = c.CreatedDate,
                            }).FirstOrDefault();

            return new() { LeaveTypeVM = leaveType };
        }
    }
}

using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.LeaveType.GetAll
{
    public class GetAllLeaveTypeHandler : IRequestHandler<GetAllLeaveTypeRequest, GetAllLeaveTypeResponse>
    {
        public ILeaveTypeReadRepository _LeaveTypeReadRepository;

        public GetAllLeaveTypeHandler(ILeaveTypeReadRepository LeaveTypeReadRepository)
        {
            _LeaveTypeReadRepository = LeaveTypeReadRepository;
        }

        public Task<GetAllLeaveTypeResponse> Handle(GetAllLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var query = _LeaveTypeReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
               .Select(c => new LeaveTypeVM
               {
                   Id = c.Id.ToString(),
                   Name = c.Name,
                   Code = c.Code,
                   CreatedDate = c.CreatedDate,
               });
            var totalCount = query.Count();
            var leaveTypes = request.DoPagination ? query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList() : query.ToList();

            return Task.FromResult(new GetAllLeaveTypeResponse
            {
                TotalCount = totalCount,
                LeaveTypeVMs = leaveTypes,
            });
        }
    }
}

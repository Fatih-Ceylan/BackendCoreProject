using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.ShiftManagement.GetById
{
    public class GetByIdShiftManagementHandler : IRequestHandler<GetByIdShiftManagementRequest, GetByIdShiftManagementResponse>
    {
        readonly IShiftManagementReadRepository _shiftManagementReadRepository;

        public GetByIdShiftManagementHandler(IShiftManagementReadRepository shiftManagementReadRepository)
        {
            _shiftManagementReadRepository = shiftManagementReadRepository;
        }

        public async Task<GetByIdShiftManagementResponse> Handle(GetByIdShiftManagementRequest request, CancellationToken cancellationToken)
        {
            var shiftManagement = _shiftManagementReadRepository
                                .GetWhere(ds => ds.Id == Guid.Parse(request.Id))
                                .Select(ds => new ShiftManagementVM
                                {
                                    Id = ds.Id.ToString(),
                                    Title = ds.Title,
                                    ShiftStartDate = ds.ShiftStartDate,
                                    ShiftEndDate = ds.ShiftEndDate
                                }).FirstOrDefault();
            return new()
            {
                ShiftManagement = shiftManagement
            };
        }
    }
}

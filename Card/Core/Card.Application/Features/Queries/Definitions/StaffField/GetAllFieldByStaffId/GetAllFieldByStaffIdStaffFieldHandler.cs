using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffField.GetAllFieldByStaffId
{
    public class GetAllFieldByStaffIdStaffFieldHandler : IRequestHandler<GetAllFieldByStaffIdStaffFieldRequest, GetAllFieldByStaffIdStaffFieldResponse>
    {
        readonly IStaffFieldReadRepository _staffFieldReadRepository;

        public GetAllFieldByStaffIdStaffFieldHandler(IStaffFieldReadRepository staffFieldReadRepository)
        {
            _staffFieldReadRepository = staffFieldReadRepository;
        }

        public Task<GetAllFieldByStaffIdStaffFieldResponse> Handle(GetAllFieldByStaffIdStaffFieldRequest request, CancellationToken cancellationToken)
        {
            var query = _staffFieldReadRepository
                .GetWhere(c => c.StaffId == Guid.Parse(request.Id), false)
                .OrderBy(c => c.RowNumber)
                .Select(c => new StaffFieldVM
                {
                    Id = c.Id.ToString(),
                    FieldId = c.FieldId.ToString(),
                    FieldName = c.Field.Name,
                    RowNumber = c.RowNumber,
                    StaffId = c.StaffId.ToString(),
                    BranchId = c.BranchId.ToString(),
                    CompanyId = c.CompanyId.ToString(),
                    BranchName = c.Branch.Name,
                    CompanyName = c.Branch.Company.Name

                });

            var staffFields = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            var totalCount = staffFields.Count();

            return Task.FromResult(new GetAllFieldByStaffIdStaffFieldResponse
            {
                TotalCount = totalCount,
                StaffFields = staffFields
            });

        }
    }
}

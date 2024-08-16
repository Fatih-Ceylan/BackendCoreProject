using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffField.GetById
{
    public class GetByIdStaffFieldHandler : IRequestHandler<GetByIdStaffFieldRequest, GetByIdStaffFieldResponse>
    {
        readonly IStaffFieldReadRepository _staffFieldReadRepository;

        public GetByIdStaffFieldHandler(IStaffFieldReadRepository staffFieldReadRepository)
        {
            _staffFieldReadRepository = staffFieldReadRepository;
        }

        public async Task<GetByIdStaffFieldResponse> Handle(GetByIdStaffFieldRequest request, CancellationToken cancellationToken)
        {
            var staffField = _staffFieldReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new StaffFieldVM
                            {
                                Id = c.Id.ToString(),
                                FieldName = c.Field.Name,
                                RowNumber = c.RowNumber,
                                StaffId = c.StaffId.ToString(),
                                FieldId = c.FieldId.ToString(),
                                BranchId = c.BranchId.ToString(),
                                CompanyId = c.CompanyId.ToString(),
                                BranchName = c.Branch.Name,
                                CompanyName = c.Branch.Company.Name

                            }).OrderByDescending(c => c.RowNumber).FirstOrDefault();

            return new()
            {
                StaffField = staffField
            };
        }
    }
}

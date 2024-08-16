using BaseProject.Application.Abstractions.Services.Definitions;
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffField.GetAll
{
    public class GetAllStaffFieldHandler : IRequestHandler<GetAllStaffFieldRequest, GetAllStaffFieldResponse>
    {
        readonly IStaffFieldReadRepository _staffFieldReadRepository;
        readonly IBranchService _branchService;

        public GetAllStaffFieldHandler(IStaffFieldReadRepository staffFieldReadRepository, IBranchService branchService)
        {
            _staffFieldReadRepository = staffFieldReadRepository;
            _branchService = branchService;
        }

        public async Task<GetAllStaffFieldResponse> Handle(GetAllStaffFieldRequest request, CancellationToken cancellationToken)
        {  

            var staffFieldQuery = _staffFieldReadRepository.GetAllDeletedStatusDesc(false);

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                staffFieldQuery = staffFieldQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                staffFieldQuery = staffFieldQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var staffFields = staffFieldQuery.Select(c => new StaffFieldVM
            {
                Id = c.Id.ToString(),
                FieldId = c.FieldId.ToString(),
                FieldName = c.Field.Name,
                RowNumber = c.RowNumber,
                StaffId = c.StaffId.ToString(),
                CompanyId = c.CompanyId.ToString(),
                CompanyName=c.Branch.Company.Name,
                BranchId = c.BranchId.ToString(),
                BranchName = c.Branch.Name
            }).ToList(); 

            var totalCount = staffFields.Count;

            var response = staffFields.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllStaffFieldResponse
            {
                TotalCount = totalCount,
                StaffFields = response
            };
        }
    }
}

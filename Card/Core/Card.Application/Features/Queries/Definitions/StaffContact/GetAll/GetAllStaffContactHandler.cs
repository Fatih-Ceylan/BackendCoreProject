using BaseProject.Application.Abstractions.Services.Definitions;
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetAll
{
    public class GetAllStaffContactHandler : IRequestHandler<GetAllStaffContactRequest, GetAllStaffContactResponse>
    {
        readonly IStaffContactReadRepository _staffContactReadRepository;
        readonly IBranchService _branchService;

        public GetAllStaffContactHandler(IStaffContactReadRepository staffContactReadRepository, IBranchService branchService)
        {
            _staffContactReadRepository = staffContactReadRepository;
            _branchService = branchService;
        }

        public async Task<GetAllStaffContactResponse> Handle(GetAllStaffContactRequest request, CancellationToken cancellationToken)
        {

            var staffContactQuery = _staffContactReadRepository.GetAllDeletedStatusDesc(false);

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                staffContactQuery = staffContactQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                staffContactQuery = staffContactQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var staffContacts =await staffContactQuery.Select(s => new StaffContactVM
            {
                Id = s.Id.ToString(),
                StaffId = s.StaffId.ToString(),
                ContactId = s.ContactId.ToString(),
                CreatedDate = s.CreatedDate,
                ContactName = s.ContactName,
                StaffName = s.Staff.Name,
                CompanyId = s.CompanyId.ToString(),
                CompanyName = s.Branch.Company.Name,
                BranchId = s.BranchId.ToString(),
                BranchName = s.Branch.Name,

            }).ToListAsync(cancellationToken); 

            var totalCount = staffContacts.Count;

            var response = staffContacts.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllStaffContactResponse
            {
                TotalCount = totalCount,
                StaffContacts = response,
            };
        }
    }
}

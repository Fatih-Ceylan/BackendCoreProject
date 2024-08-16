using BaseProject.Application.Abstractions.Services.Definitions;
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.Staff.GetAll
{
    public class GetAllStaffHandler : IRequestHandler<GetAllStaffRequest, GetAllStaffResponse>
    {
        readonly IStaffReadRepository _staffReadRepository;
        readonly IBranchService _branchService;
        public GetAllStaffHandler(IStaffReadRepository staffReadRepository, IBranchService branchService)
        {
            _staffReadRepository = staffReadRepository;
            _branchService = branchService;
        }

        public async Task<GetAllStaffResponse> Handle(GetAllStaffRequest request, CancellationToken cancellationToken)
        { 

            var staffQuery = _staffReadRepository.GetAllDeletedStatusDesc(false);

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                staffQuery = staffQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                staffQuery = staffQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var staffs = await staffQuery.Select(s => new StaffVM
            {
                Id = s.Id.ToString(),
                Email = s.Email,
                LastName = s.LastName,
                Title = s.Title,
                CreatedDate = s.CreatedDate,
                Description = s.Description != null ? s.Description : null,
                Name = s.Name,
                UserName = s.UserName,
                Password = s.Password,
                Token = s.Token,
                PhoneNumber = s.PhoneNumber,
                CompanyId = s.CompanyId.ToString(),
                CompanyName=s.Branch.Company.Name,
                BranchId = s.BranchId.ToString(),
                BranchName=s.Branch.Name,
                StaffUrl = s.StaffUrl,

            }).ToListAsync(cancellationToken); 

            var totalCount = staffs.Count;

            var response = staffs.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllStaffResponse
            {
                TotalCount = totalCount,
                Staffs = response,
            };
        }
    }
}

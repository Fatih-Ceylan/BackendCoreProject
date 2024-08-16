using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.PhoneNumber.GetAll
{
    public class GetAllPhoneNumberHandler : IRequestHandler<GetAllPhoneNumberRequest, GetAllPhoneNumberResponse>
    {
        readonly IPhoneNumberReadRepository _phoneNumberReadRepository; 

        public GetAllPhoneNumberHandler(IPhoneNumberReadRepository phoneNumberReadRepository)
        {
            _phoneNumberReadRepository = phoneNumberReadRepository; 
        }

        public async Task<GetAllPhoneNumberResponse> Handle(GetAllPhoneNumberRequest request, CancellationToken cancellationToken)
        { 

            var phoneNumberQuery = _phoneNumberReadRepository.GetAllDeletedStatusDesc(false);

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                phoneNumberQuery = phoneNumberQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                phoneNumberQuery = phoneNumberQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var phoneNumbers = await phoneNumberQuery.Select(p => new PhoneNumberVM
            {
                Id = p.Id.ToString(),
                CreatedDate = p.CreatedDate,
                StaffId = p.Staff.Id.ToString(),
                Number = p.Number,
                StaffName = $"{p.Staff.Name} {p.Staff.LastName}",
                CompanyId = p.CompanyId.ToString(),
                CompanyName =p.Branch.Company.Name,
                BranchId = p.BranchId.ToString(),
                BranchName = p.Branch.Name,

            }).ToListAsync(cancellationToken); 

            var totalCount = phoneNumbers.Count;

            var response = phoneNumbers.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllPhoneNumberResponse
            {
                TotalCount = totalCount,
                PhoneNumbers = response
            };
        }
    }
}

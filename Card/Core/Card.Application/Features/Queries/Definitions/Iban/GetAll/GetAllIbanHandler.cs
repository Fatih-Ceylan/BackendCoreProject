using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.Iban.GetAll
{
    public class GetAllIbanHandler : IRequestHandler<GetAllIbanRequest, GetAllIbanResponse>
    {
        readonly IIbanReadRepository _ibanReadRepository; 

        public GetAllIbanHandler(IIbanReadRepository ibanReadRepository)
        {
            _ibanReadRepository = ibanReadRepository; 
        }

        public async Task<GetAllIbanResponse> Handle(GetAllIbanRequest request, CancellationToken cancellationToken)
        {
            var ibanQuery = _ibanReadRepository.GetAllDeletedStatusDesc(false);

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                ibanQuery = ibanQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                ibanQuery = ibanQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var ibans = await ibanQuery.Select(i => new IbanVM
            {
                Id = i.Id.ToString(),
                CreatedDate = i.CreatedDate,
                IbanNo = i.IbanNo,
                StaffId = i.Staff.Id.ToString(),
                StaffName = $"{i.Staff.Name} {i.Staff.LastName}",
                CompanyId = i.CompanyId.ToString(),
                BranchId = i.BranchId.ToString(),
                CompanyName = i.Branch.Company.Name,
                BranchName = i.Branch.Name

            }).ToListAsync(cancellationToken); 

            var totalCount = ibans.Count;

            var response = ibans.Skip(request.Page * request.Size).Take(request.Size).ToList();
             
            return new GetAllIbanResponse
            {
                TotalCount = totalCount,
                Ibans = response
            };
        }
    }
}

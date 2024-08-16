using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetById
{
    public class GetByIdStaffContactIdHandler : IRequestHandler<GetByIdStaffContactRequest, GetByIdStaffContactResponse>
    {
        readonly IStaffContactReadRepository _staffContactReadRepository;

        public GetByIdStaffContactIdHandler(IStaffContactReadRepository staffContactReadRepository)
        {
            _staffContactReadRepository = staffContactReadRepository;
        }

        public async Task<GetByIdStaffContactResponse> Handle(GetByIdStaffContactRequest request, CancellationToken cancellationToken)
        {
            var contact = _staffContactReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new StaffContactVM
                           {
                               Id = c.Id.ToString(),
                               StaffId = c.Staff.Id.ToString(),
                               ContactId = c.ContactId.ToString(),
                               CreatedDate = c.CreatedDate,
                               StaffName = c.Staff.Name,
                               ContactName = c.ContactName,
                               CompanyId = c.CompanyId.ToString(),
                               CompanyName = c.Branch.Company.Name,
                               BranchId = c.BranchId.ToString(),
                               BranchName = c.Branch.Name

                           }).FirstOrDefault();

            return new()
            {
                StaffContact = contact
            };
        }
    }
}

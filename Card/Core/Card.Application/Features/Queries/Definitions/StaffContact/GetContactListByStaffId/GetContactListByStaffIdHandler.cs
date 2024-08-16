using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetContactListByStaffId
{
    public class GetContactListByStaffIdHandler : IRequestHandler<GetContactListByStaffIdRequest, GetContactListByStaffIdResponse>
    {
        readonly IStaffContactReadRepository _staffContactReadRepository;
        readonly IStaffReadRepository _staffReadRepository;

        public GetContactListByStaffIdHandler(IStaffContactReadRepository staffContactReadRepository, IStaffReadRepository staffReadRepository)
        {
            _staffContactReadRepository = staffContactReadRepository;
            _staffReadRepository = staffReadRepository;
        }

        public Task<GetContactListByStaffIdResponse> Handle(GetContactListByStaffIdRequest request, CancellationToken cancellationToken)
        {

            var query = _staffContactReadRepository.GetWhere(c => c.StaffId == Guid.Parse(request.Id), false)
                                                    .Select(c => new StaffContactVM
                                                    {
                                                        Id = c.Id.ToString(),
                                                        ContactId = c.ContactId.ToString(),
                                                        StaffId = c.StaffId.ToString(),
                                                        StaffName = c.Staff.Name,
                                                        CreatedDate = c.CreatedDate,
                                                        ContactName = c.ContactName,
                                                        CompanyId = c.CompanyId.ToString(),
                                                        CompanyName = c.Branch.Company.Name,
                                                        BranchId = c.BranchId.ToString(),
                                                        BranchName = c.Branch.Name

                                                    });

            var totalCount = query.Count();
            var contacts = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetContactListByStaffIdResponse
            {
                TotalCount = totalCount,
                Contacts = contacts,
            });
        }
    }
}

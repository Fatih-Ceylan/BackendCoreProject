using Card.Application.Abstractions.Mail;
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Staff.GetById
{
    public class GetByIdStaffHandler : IRequestHandler<GetByIdStaffRequest, GetByIdStaffResponse>
    {
        readonly IStaffReadRepository _staffReadRepository;
        readonly IMailService _mailService;
        //TODO: Şirket logosu eklenecek.

        public GetByIdStaffHandler(IStaffReadRepository staffReadRepository, IMailService mailService)
        {
            _staffReadRepository = staffReadRepository;
            _mailService = mailService;
        }

        public async Task<GetByIdStaffResponse> Handle(GetByIdStaffRequest request, CancellationToken cancellationToken)
        {
            var staff = _staffReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new StaffVM
                           {
                               Id = c.Id.ToString(),
                               Name = c.Name,
                               Email = c.Email,
                               LastName = c.LastName,
                               Title = c.Title,
                               ProfilePicturePath = c.ProfilePicturePath,
                               Description = c.Description != null ? c.Description : null,
                               CreatedDate = c.CreatedDate,
                               UserName = c.UserName,
                               Password = c.Password,
                               Token = c.Token,
                               PhoneNumber = c.PhoneNumber,
                               BranchId = c.BranchId.ToString(),
                               CompanyId = c.CompanyId.ToString(),
                               BranchName = c.Branch.Name,
                               CompanyName = c.Branch.Company.Name

                           }).FirstOrDefault(); 

            return new()
            {
                Staff = staff
            };
        }
    }
}

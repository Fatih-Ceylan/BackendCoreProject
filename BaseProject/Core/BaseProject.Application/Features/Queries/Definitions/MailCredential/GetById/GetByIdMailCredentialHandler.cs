using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.MailCredential;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Aes256;

namespace BaseProject.Application.Features.Queries.Definitions.MailCredential.GetById
{
    public class GetByIdMailCredentialHandler : IRequestHandler<GetByIdMailCredentialRequest, GetByIdMailCredentialResponse>
    {
        readonly IMailCredentialReadRepository _mailCredentialReadRepository;
        readonly IAes256Service _aes256Service;

        public GetByIdMailCredentialHandler(IMailCredentialReadRepository mailCredentialReadRepository, IAes256Service aes256Service)
        {
            _mailCredentialReadRepository = mailCredentialReadRepository;
            _aes256Service = aes256Service;
        }

        public async Task<GetByIdMailCredentialResponse> Handle(GetByIdMailCredentialRequest request, CancellationToken cancellationToken)
        {
            var mailCredential = _mailCredentialReadRepository
                                .GetWhere(mc => mc.Id == Guid.Parse(request.Id), false)
                                .Select(mc => new MailCredentialVM
                                {
                                    Id = mc.Id.ToString(),
                                    CreatedDate = mc.CreatedDate,
                                    CompanyId = mc.CompanyId.ToString(),
                                    CompanyName = mc.Branch.Company.Name,
                                    BranchId = mc.BranchId.ToString(),
                                    BranchName = mc.Branch.Name,
                                    UserId = mc.UserId,
                                    UserName = mc.User.UserName,
                                    From = mc.From,
                                    //FromPassword = _aes256Service.Decrypt(mc.FromPassword),
                                    DisplayName = mc.DisplayName,
                                    Port = mc.Port,
                                    Host = mc.Host,
                                    EnableSsl = mc.EnableSsl,
                                    IsVerified = mc.IsVerified,
                                    IsActive = mc.IsActive,
                                }).FirstOrDefault();

            return new()
            {
                MailCredential = mailCredential
            };
        }
    }
}
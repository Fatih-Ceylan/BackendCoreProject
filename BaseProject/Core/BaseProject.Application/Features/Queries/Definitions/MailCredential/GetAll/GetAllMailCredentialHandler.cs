using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.MailCredential;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Aes256;

namespace BaseProject.Application.Features.Queries.Definitions.MailCredential.GetAll
{
    public class GetAllMailCredentialHandler : IRequestHandler<GetAllMailCredentialRequest, GetAllMailCredentialResponse>
    {
        readonly IMailCredentialReadRepository _mailCredentialReadRepository;
        readonly IAes256Service _aes256Service;

        public GetAllMailCredentialHandler(IMailCredentialReadRepository mailCredentialReadRepository, IAes256Service aes256Service)
        {
            _mailCredentialReadRepository = mailCredentialReadRepository;
            _aes256Service = aes256Service;
        }

        public async Task<GetAllMailCredentialResponse> Handle(GetAllMailCredentialRequest request, CancellationToken cancellationToken)
        {
            var query = _mailCredentialReadRepository
                       .GetAllDeletedStatusDesc(false)
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
                       });
            var totalCount = query.Count();
            var mailCredentials = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                              .Take(request.Size).ToList()
                                                       : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                MailCredentials = mailCredentials
            };
        }
    }
}
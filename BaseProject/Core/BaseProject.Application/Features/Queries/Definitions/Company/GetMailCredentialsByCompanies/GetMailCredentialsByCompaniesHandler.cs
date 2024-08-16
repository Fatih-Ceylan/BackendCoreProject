using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.Branch;
using BaseProject.Application.VMs.Definitions.Company;
using BaseProject.Application.VMs.Definitions.MailCredential;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Aes256;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetMailCredentialsByCompanies
{
    public class GetMailCredentialsByCompaniesHandler : IRequestHandler<GetMailCredentialsByCompaniesRequest, GetMailCredentialsByCompaniesResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IBranchReadRepository _branchReadRepository;
        readonly IMailCredentialReadRepository _mailCredantReadRepository;
        readonly IAes256Service _aes256Service;

        public GetMailCredentialsByCompaniesHandler(ICompanyReadRepository companyReadRepository, IBranchReadRepository branchReadRepository, IMailCredentialReadRepository mailCredantReadRepository, IAes256Service aes256Service)
        {
            _companyReadRepository = companyReadRepository;
            _branchReadRepository = branchReadRepository;
            _mailCredantReadRepository = mailCredantReadRepository;
            _aes256Service = aes256Service;
        }

        public async Task<GetMailCredentialsByCompaniesResponse> Handle(GetMailCredentialsByCompaniesRequest request, CancellationToken cancellationToken)
        {
            var companyMailCredentials =
         _companyReadRepository.GetAllDeletedStatusDesc(false)
                               .Select(c => new CompanyMailCredentialVM
                               {
                                   Id = c.Id.ToString(),
                                   Name = c.Name,
                                   BranchCount = _branchReadRepository.GetAllDeletedStatusDesc(false, false)
                                                                      .Where(b => b.CompanyId == c.Id)
                                                                      .Count(),
                                   Branches = _branchReadRepository.GetAllDeletedStatusDesc(false, false)
                                                                   .Where(b => b.CompanyId == c.Id)
                                                                   .Select(b => new BranchMailCredentialVM
                                                                   {
                                                                       Id = b.Id.ToString(),
                                                                       Name = b.Name,
                                                                       MailCredential = _mailCredantReadRepository.GetAllDeletedStatusDesc(false, false)
                                                                                                                  .Where(mc => mc.BranchId == b.Id)
                                                                                                                  .Select(mc => new MailCredentialUpdateVM
                                                                                                                  {
                                                                                                                      Id = mc.Id.ToString(),
                                                                                                                      From = mc.From,
                                                                                                                      Host = mc.Host,
                                                                                                                      Port = mc.Port,
                                                                                                                      //Password = mc.FromPassword,
                                                                                                                      DisplayName = mc.DisplayName,
                                                                                                                      EnableSsl = mc.EnableSsl,
                                                                                                                      IsActive = mc.IsActive
                                                                                                                  }).FirstOrDefault()
                                                                   }).ToList()
                               }).ToList();

            return new()
            {
                TotalCount = companyMailCredentials.Count,
                CompanyMailCredentials = companyMailCredentials
            };
        }
    }
}
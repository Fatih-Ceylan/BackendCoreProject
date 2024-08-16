using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.Company.Delete
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyRequest, DeleteCompanyResponse>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;
        readonly ICompanyReadRepository _companyReadRepository;

        public DeleteCompanyHandler(ICompanyWriteRepository companyWriteRepository, ICompanyReadRepository companyReadRepository)
        {
            _companyWriteRepository = companyWriteRepository;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<DeleteCompanyResponse> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = await _companyReadRepository.GetByIdAsync(request.Id);
            company.IsDeleted = true;

            await _companyWriteRepository.SaveAsync();

            DeleteCompanyResponse deleteCompanyResponse = new();
            deleteCompanyResponse.MessageList = new();
            deleteCompanyResponse.MessageList.Add(CommandResponseMessage.DeletedSuccess.ToString());
            deleteCompanyResponse.UrlPath = company.UrlPath;

            return deleteCompanyResponse;
        }
    }
}
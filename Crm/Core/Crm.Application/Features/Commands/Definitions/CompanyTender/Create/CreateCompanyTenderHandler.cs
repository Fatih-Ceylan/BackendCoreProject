using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;



namespace GCrm.Application.Features.Commands.Definitions.CompanyTender.Create
{
    public class CreateCompanyTenderHandler : IRequestHandler<CreateCompanyTenderRequest, CreateCompanyTenderResponse>
    {
        readonly ICompanyTenderWriteRepository _companyTenderWriteRepository;
        readonly IMapper _mapper;

        public CreateCompanyTenderHandler(ICompanyTenderWriteRepository companyTenderWriteRepository, IMapper mapper)
        {
            _companyTenderWriteRepository = companyTenderWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCompanyTenderResponse> Handle(CreateCompanyTenderRequest request, CancellationToken cancellationToken)
        {
            var companytender = _mapper.Map<T.CompanyTender>(request);

            companytender = await _companyTenderWriteRepository.AddAsync(companytender);
            await _companyTenderWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCompanyTenderResponse>(companytender);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

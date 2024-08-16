using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;


namespace GCrm.Application.Features.Commands.Definitions.CompanyContactName.Create
{
    public class CreateCompanyContactNameHandler : IRequestHandler<CreateCompanyContactNameRequest, CreateCompanyContactNameResponse>
    {
        readonly ICompanyContactNameWriteRepository _companyContactNameWriteRepository;
        readonly IMapper _mapper;

        public CreateCompanyContactNameHandler(ICompanyContactNameWriteRepository companyContactNameWriteRepository, IMapper mapper)
        {
            _companyContactNameWriteRepository = companyContactNameWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCompanyContactNameResponse> Handle(CreateCompanyContactNameRequest request, CancellationToken cancellationToken)
        {
            var companycontactname = _mapper.Map<T.CompanyContactName>(request);

            companycontactname = await _companyContactNameWriteRepository.AddAsync(companycontactname);
            await _companyContactNameWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCompanyContactNameResponse>(companycontactname);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

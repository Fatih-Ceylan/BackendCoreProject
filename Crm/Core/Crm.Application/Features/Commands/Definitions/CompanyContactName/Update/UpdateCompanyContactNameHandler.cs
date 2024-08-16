using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CompanyContactName.Update
{
    public class UpdateCompanyContactNameHandler : IRequestHandler<UpdateCompanyContactNameRequest, UpdateCompanyContactNameResponse>
    {

        readonly ICompanyContactNameWriteRepository _companyContactNameWriteRepository;
        readonly ICompanyContactNameReadRepository _companyContactNameReadRepository;
        readonly IMapper _mapper;

        public UpdateCompanyContactNameHandler(ICompanyContactNameWriteRepository companyContactNameWriteRepository, ICompanyContactNameReadRepository companyContactNameReadRepository, IMapper mapper)
        {
            _companyContactNameWriteRepository = companyContactNameWriteRepository;
            _companyContactNameReadRepository = companyContactNameReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateCompanyContactNameResponse> Handle(UpdateCompanyContactNameRequest request, CancellationToken cancellationToken)
        {
            var companycontactname = await _companyContactNameReadRepository.GetByIdAsync(request.Id);
            companycontactname = _mapper.Map(request, companycontactname);
            await _companyContactNameWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCompanyContactNameResponse>(companycontactname);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

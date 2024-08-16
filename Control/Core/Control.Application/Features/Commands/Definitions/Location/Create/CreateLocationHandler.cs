using AutoMapper;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.Location.Create
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationRequest, CreateLocationResponse>
    {
        readonly ILocationWriteRepository _locationWriteRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository _companyReadRepository;
        public CreateLocationHandler(ILocationWriteRepository locationWriteRepository, IMapper mapper, BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository companyReadRepository)
        {
            _locationWriteRepository = locationWriteRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<CreateLocationResponse> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }

            var location = _mapper.Map<T.Location>(request);
            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                location.CompanyId = mainCompanyId;
            }
            location = await _locationWriteRepository.AddAsync(location);
            await _locationWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateLocationResponse>(location);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

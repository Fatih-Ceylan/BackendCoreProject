using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.EducationInfo.Create
{
    public class CreateEducationInfoHandler : IRequestHandler<CreateEducationInfoRequest, CreateEducationInfoResponse>
    {
        readonly IEducationInfoWriteRepository _educationInfoWriteRepository;
        readonly IMapper _mapper;

        public CreateEducationInfoHandler(IEducationInfoWriteRepository educationInfoWriteRepository, IMapper mapper)
        {
            _educationInfoWriteRepository = educationInfoWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateEducationInfoResponse> Handle(CreateEducationInfoRequest request, CancellationToken cancellationToken)
        {
            var educationInfo = _mapper.Map<BaseProject.Domain.Entities.HR.Employment.EducationInfo>(request);

            educationInfo = await _educationInfoWriteRepository.AddAsync(educationInfo);
            await _educationInfoWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateEducationInfoResponse>(educationInfo);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

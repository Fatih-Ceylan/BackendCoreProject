using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.EducationInfo.Update
{
    public class UpdateEducationInfoHandler : IRequestHandler<UpdateEducationInfoRequest, UpdateEducationInfoResponse>
    {
        public IMapper _mapper;
        public IEducationInfoReadRepository _educationInfoReadRepository;
        public IEducationInfoWriteRepository _educationInfoWriteRepository;

        public UpdateEducationInfoHandler(IMapper mapper, IEducationInfoReadRepository EducationInfoReadRepository, IEducationInfoWriteRepository EducationInfoWriteRepository)
        {
            _mapper = mapper;
            _educationInfoReadRepository = EducationInfoReadRepository;
            _educationInfoWriteRepository = EducationInfoWriteRepository;
        }

        public async Task<UpdateEducationInfoResponse> Handle(UpdateEducationInfoRequest request, CancellationToken cancellationToken)
        {
            var educationInfo = await _educationInfoReadRepository.GetByIdAsync(request.Id);
            educationInfo = _mapper.Map(request, educationInfo);
            await _educationInfoWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateEducationInfoResponse>(educationInfo);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

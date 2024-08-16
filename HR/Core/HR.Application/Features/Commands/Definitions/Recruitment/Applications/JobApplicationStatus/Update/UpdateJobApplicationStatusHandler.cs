using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicationStatus.Update
{
    public class UpdateJobApplicationStatusHandler : IRequestHandler<UpdateJobApplicationStatusRequest, UpdateJobApplicationStatusResponse>
    {
        public IMapper _mapper;
        public IJobApplicationStatusReadRepository _jobApplicationStatusReadRepository;
        public IJobApplicationStatusWriteRepository _jobApplicationStatusWriteRepository;

        public UpdateJobApplicationStatusHandler(IMapper mapper, IJobApplicationStatusReadRepository JobApplicationStatusReadRepository, IJobApplicationStatusWriteRepository JobApplicationStatusWriteRepository)
        {
            _mapper = mapper;
            _jobApplicationStatusReadRepository = JobApplicationStatusReadRepository;
            _jobApplicationStatusWriteRepository = JobApplicationStatusWriteRepository;
        }

        public async Task<UpdateJobApplicationStatusResponse> Handle(UpdateJobApplicationStatusRequest request, CancellationToken cancellationToken)
        {
            var jobApplicationStatus = await _jobApplicationStatusReadRepository.GetByIdAsync(request.Id);
            jobApplicationStatus = _mapper.Map(request, jobApplicationStatus);
            await _jobApplicationStatusWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateJobApplicationStatusResponse>(jobApplicationStatus);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

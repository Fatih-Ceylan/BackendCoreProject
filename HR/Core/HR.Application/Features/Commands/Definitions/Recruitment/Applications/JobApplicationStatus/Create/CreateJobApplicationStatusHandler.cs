using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicationStatus.Create
{
    public class CreateJobApplicationStatusStatusHandler : IRequestHandler<CreateJobApplicationStatusRequest, CreateJobApplicationStatusResponse>
    {
        readonly IMapper _mapper;
        readonly IJobApplicationStatusWriteRepository _jobApplicationStatusWriteRepository;

        public CreateJobApplicationStatusStatusHandler(IMapper mapper, IJobApplicationStatusWriteRepository JobApplicationStatusWriteRepository)
        {
            _mapper = mapper;
            _jobApplicationStatusWriteRepository = JobApplicationStatusWriteRepository;
        }

        public async Task<CreateJobApplicationStatusResponse> Handle(CreateJobApplicationStatusRequest request, CancellationToken cancellationToken)
        {
            var jobApplicationStatus = _mapper.Map<BaseProject.Domain.Entities.HR.Recruitment.Applications.JobApplicationStatus>(request);
            jobApplicationStatus = await _jobApplicationStatusWriteRepository.AddAsync(jobApplicationStatus);
            await _jobApplicationStatusWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateJobApplicationStatusResponse>(jobApplicationStatus);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

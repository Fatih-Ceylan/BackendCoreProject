using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplication.Create
{
    public class CreateJobApplicationHandler : IRequestHandler<CreateJobApplicationRequest, CreateJobApplicationResponse>
    {
        readonly IMapper _mapper;
        readonly IJobApplicationWriteRepository _jobApplicationWriteRepository;

        public CreateJobApplicationHandler(IMapper mapper, IJobApplicationWriteRepository JobApplicationWriteRepository)
        {
            _mapper = mapper;
            _jobApplicationWriteRepository = JobApplicationWriteRepository;
        }

        public async Task<CreateJobApplicationResponse> Handle(CreateJobApplicationRequest request, CancellationToken cancellationToken)
        {
            var jobApplication = _mapper.Map<BaseProject.Domain.Entities.HR.Recruitment.Applications.JobApplication>(request);
            jobApplication = await _jobApplicationWriteRepository.AddAsync(jobApplication);
            await _jobApplicationWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateJobApplicationResponse>(jobApplication);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

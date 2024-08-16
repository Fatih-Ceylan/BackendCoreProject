using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicant.Create
{
    public class CreateJobApplicantHandler : IRequestHandler<CreateJobApplicantRequest, CreateJobApplicantResponse>
    {
        readonly IMapper _mapper;
        readonly IJobApplicantWriteRepository _jobApplicantWriteRepository;

        public CreateJobApplicantHandler(IMapper mapper, IJobApplicantWriteRepository JobApplicantWriteRepository)
        {
            _mapper = mapper;
            _jobApplicantWriteRepository = JobApplicantWriteRepository;
        }

        public async Task<CreateJobApplicantResponse> Handle(CreateJobApplicantRequest request, CancellationToken cancellationToken)
        {
            var jobApplicant = _mapper.Map<BaseProject.Domain.Entities.HR.Recruitment.Applications.JobApplicant>(request);
            jobApplicant = await _jobApplicantWriteRepository.AddAsync(jobApplicant);
            await _jobApplicantWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateJobApplicantResponse>(jobApplicant);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

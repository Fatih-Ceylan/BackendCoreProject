using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicant.Update
{
    public class UpdateJobApplicantHandler : IRequestHandler<UpdateJobApplicantRequest, UpdateJobApplicantResponse>
    {
        public IMapper _mapper;
        public IJobApplicantReadRepository _jobApplicantReadRepository;
        public IJobApplicantWriteRepository _jobApplicantWriteRepository;

        public UpdateJobApplicantHandler(IMapper mapper, IJobApplicantReadRepository JobApplicantReadRepository, IJobApplicantWriteRepository JobApplicantWriteRepository)
        {
            _mapper = mapper;
            _jobApplicantReadRepository = JobApplicantReadRepository;
            _jobApplicantWriteRepository = JobApplicantWriteRepository;
        }

        public async Task<UpdateJobApplicantResponse> Handle(UpdateJobApplicantRequest request, CancellationToken cancellationToken)
        {
            var jobApplicant = await _jobApplicantReadRepository.GetByIdAsync(request.Id);
            jobApplicant = _mapper.Map(request, jobApplicant);

            var updatedResponse = _mapper.Map<UpdateJobApplicantResponse>(jobApplicant);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

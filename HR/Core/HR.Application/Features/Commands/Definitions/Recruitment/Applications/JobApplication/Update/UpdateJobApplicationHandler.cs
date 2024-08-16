using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.HR.Recruitment.Applications;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplication.Update
{
    public class UpdateJobApplicationHandler : IRequestHandler<UpdateJobApplicationRequest, UpdateJobApplicationResponse>
    {
        public IMapper _mapper;
        public IJobApplicationReadRepository _jobApplicationReadRepository;
        public IJobApplicationWriteRepository _jobApplicationWriteRepository;
        public IJobApplicationStatusHistoryReadRepository _jobApplicationStatusHistoryReadRepository;
        public IJobApplicationStatusHistoryWriteRepository _jobApplicationStatusHistoryWriteRepository;

        public UpdateJobApplicationHandler(IMapper mapper, IJobApplicationReadRepository JobApplicationReadRepository, IJobApplicationWriteRepository JobApplicationWriteRepository, IJobApplicationStatusHistoryReadRepository jobApplicationStatusHistoryReadRepository, IJobApplicationStatusHistoryWriteRepository jobApplicationStatusHistoryWriteRepository)
        {
            _mapper = mapper;
            _jobApplicationReadRepository = JobApplicationReadRepository;
            _jobApplicationWriteRepository = JobApplicationWriteRepository;
            _jobApplicationStatusHistoryReadRepository = jobApplicationStatusHistoryReadRepository;
            _jobApplicationStatusHistoryWriteRepository = jobApplicationStatusHistoryWriteRepository;
        }

        public async Task<UpdateJobApplicationResponse> Handle(UpdateJobApplicationRequest request, CancellationToken cancellationToken)
        {
            var jobApplication = await _jobApplicationReadRepository.GetByIdAsyncIncluding([ j=>j.JobApplicationStatus.JobApplicationStatusHistories
            ], request.Id);
            jobApplication = _mapper.Map(request, jobApplication);
            var saved = await _jobApplicationWriteRepository.SaveAsync();

            if (saved == 0)
            {
                if (jobApplication.JobApplicationStatus.JobApplicationStatusHistories != null)
                {
                    var status = _jobApplicationStatusHistoryReadRepository.GetByIdAsync(jobApplication.JobApplicationStatus.JobApplicationStatusHistories.FirstOrDefault().Id.ToString());
                }
                else
                {
                    var history = new T.JobApplicationStatusHistory()
                    {
                        Id = Guid.NewGuid(),
              
                        JobApplicationStatusId = jobApplication.JobApplicationStatusId,
                        CreatedDate = DateTime.Now
                    };

                    await _jobApplicationStatusHistoryWriteRepository.AddAsync(history);
                    await _jobApplicationStatusHistoryWriteRepository.SaveAsync();
                }
            }
            else
            {
                //TODO custom exception handler kullan
                throw new Exception();
            }

            var updatedResponse = _mapper.Map<UpdateJobApplicationResponse>(jobApplication);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

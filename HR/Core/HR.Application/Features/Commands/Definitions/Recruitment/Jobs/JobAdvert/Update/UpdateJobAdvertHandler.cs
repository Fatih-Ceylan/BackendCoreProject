using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Jobs.JobAdvert.Update
{
    public class UpdateJobAdvertHandler : IRequestHandler<UpdateJobAdvertRequest, UpdateJobAdvertResponse>
    {
        public IMapper _mapper;
        public IJobAdvertReadRepository _jobAdvertReadRepository;
        public IJobAdvertWriteRepository _jobAdvertWriteRepository;

        public UpdateJobAdvertHandler(IMapper mapper, IJobAdvertReadRepository JobAdvertReadRepository, IJobAdvertWriteRepository JobAdvertWriteRepository)
        {
            _mapper = mapper;
            _jobAdvertReadRepository = JobAdvertReadRepository;
            _jobAdvertWriteRepository = JobAdvertWriteRepository;
        }

        public async Task<UpdateJobAdvertResponse> Handle(UpdateJobAdvertRequest request, CancellationToken cancellationToken)
        {
            var jobAdvert = await _jobAdvertReadRepository.GetByIdAsync(request.Id);
            jobAdvert = _mapper.Map(request, jobAdvert);
            await _jobAdvertWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateJobAdvertResponse>(jobAdvert);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}

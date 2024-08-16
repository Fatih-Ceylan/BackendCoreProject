using MediatR;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicationStatus.Update
{
    public class UpdateJobApplicationStatusRequest : IRequest<UpdateJobApplicationStatusResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

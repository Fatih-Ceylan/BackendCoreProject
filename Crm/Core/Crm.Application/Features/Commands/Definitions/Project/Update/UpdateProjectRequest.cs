using BaseProject.Domain.Entities.GCrm.Enums;
using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Project.Update
{
    public  class UpdateProjectRequest : IRequest<UpdateProjectResponse>
    {
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManagerId { get; set; }
        public string ProjectTeamId { get; set; }
        public DateTime ProjectStartDate { get; set; } //başlangıç tarihi
        public DateTime ProjectFinishDate { get; set; } //bitiş tarihi
        //public ProjectTypeEnum ProjectTypeEnum { get; set; } //projetipi
        //public ProjectStatuEnum ProjectStatuEnum { get; set; }  //proje durumu
        public ProjectPriorityEnum ProjectPriorityEnum { get; set; } //proje öncelik
        public string Description { get; set; }

    }
}

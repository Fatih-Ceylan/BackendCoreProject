using BaseProject.Domain.Entities.GCrm.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GCrm.Application.Features.Commands.Definitions.Project.Create
{
    public  class CreateProjectRequest : IRequest<CreateProjectResponse>
    {
        public string ProjectName { get; set; }
        public string ProjectManagerId { get; set; }
        public string ProjectTeamId { get; set; }
        public string CustomerId { get; set; }
        public string ProjectTypeId { get; set; }
        public string ProjectStatuesId { get; set; }
        public DateTime ProjectStartDate { get; set; } //başlangıç tarihi
        public DateTime ProjectFinishDate { get; set; } //bitiş tarihi
        //public ProjectTypeEnum ProjectTypeEnum { get; set; } //projetipi
        //public ProjectStatuEnum ProjectStatuEnum { get; set; }  //proje durumu
        public ProjectPriorityEnum ProjectPriorityEnum { get; set; } //proje öncelik
        public string Description { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}

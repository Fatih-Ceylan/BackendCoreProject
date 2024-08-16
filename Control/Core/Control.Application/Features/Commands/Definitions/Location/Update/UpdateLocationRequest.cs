using BaseProject.Domain.Entities.GControl.Enums;
using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Location.Update
{
    public class UpdateLocationRequest : IRequest<UpdateLocationResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public int Radius { get; set; }
        public DateTime? EntryTimeLimit { get; set; }
        public bool? IsEntryTimeLimitEnabled { get; set; }
        public string Description { get; set; }
        public LocationOutEnum LocationOut { get; set; }
        public string CompanyId { get; set; } 
    }
}

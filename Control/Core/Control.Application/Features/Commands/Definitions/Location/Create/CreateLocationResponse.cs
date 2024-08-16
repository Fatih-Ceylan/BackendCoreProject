using BaseProject.Domain.Entities.GControl.Enums;

namespace GControl.Application.Features.Commands.Definitions.Location.Create
{
    public class CreateLocationResponse
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
        public string Message { get; set; }
    }
}

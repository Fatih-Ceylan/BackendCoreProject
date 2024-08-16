using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class ShiftManagement : BaseEntity
    {
        public string Title { get; set; }
        public DateTime? ShiftStartDate { get; set; }
        public DateTime ShiftEndDate { get; set; }
        public bool isActive { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

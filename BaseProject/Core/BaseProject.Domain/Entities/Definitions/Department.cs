using BaseProject.Domain.Entities.Identity;

namespace BaseProject.Domain.Entities.Definitions
{
    public class Department : B_BaseEntity
    {
        public Guid CompanyId { get; set; }

        public Guid BranchId { get; set; }

        public string Name { get; set; }

        public Guid? MainDepartmentId { get; set; }

        public Branch Branch { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

    }
}
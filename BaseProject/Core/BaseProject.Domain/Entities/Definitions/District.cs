using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Domain.Entities.Definitions
{
    public class District : B_BaseEntity
    {
        [Key]
        public int Idc { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public override Guid Id { get => base.Id; set => base.Id = value; }

        public City City { get; set; }

        public ICollection<Branch> Branches { get; set; }
    }
}

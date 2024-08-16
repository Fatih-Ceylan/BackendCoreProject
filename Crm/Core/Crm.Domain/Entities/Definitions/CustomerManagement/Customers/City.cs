using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers
{
    public class City: B_BaseEntity
    {
        [Key]
        public int Idc { get; set; }

        public int CountryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public override Guid Id { get => base.Id; set => base.Id = value; }

        public Country Country { get; set; }

        public ICollection<District> Districts { get; set; }

    }
}
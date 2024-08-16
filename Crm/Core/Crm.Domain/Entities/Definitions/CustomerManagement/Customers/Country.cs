using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers
{
    public class Country : B_BaseEntity
    {
        [Key]
        public int Idc { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public override Guid Id { get => base.Id; set => base.Id = value; }

        public ICollection<City> Cities { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers
{
    public class District : B_BaseEntity
    {
        public Guid CityId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public override Guid Id { get => base.Id; set => base.Id = value; }

        public City City { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}

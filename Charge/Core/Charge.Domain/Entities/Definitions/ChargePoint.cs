using System.ComponentModel.DataAnnotations.Schema;

namespace GCharge.Domain.Entities.Definitions
{
    public class ChargePoint
    {
        public ChargePoint()
        {
            Transactions = new HashSet<Transaction>();
            ElectricitySalesPrices = new HashSet<ElectricitySalesPrice>();
        }

        public string ChargePointId { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Longitude { get; set; }
        public string? ClientCertThumb { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public virtual ICollection<ElectricitySalesPrice> ElectricitySalesPrices { get; set; }
    }
}

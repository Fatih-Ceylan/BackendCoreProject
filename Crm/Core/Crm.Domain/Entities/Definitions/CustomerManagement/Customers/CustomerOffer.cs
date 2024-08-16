using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers
{
    public class CustomerOffer : BaseEntity
    {

        public string OfferNo { get; set; }

        public Guid CustomerId { get; set; }

        public Guid CustomerContactId { get; set; }

        public string OfferSubject { get; set; }

        public DateTime OfferDate { get; set; }

        public int TotalAmount { get; set; }

        public string OfferStatus { get; set; }

        //public Customer Customer { get; set; }

        //public CustomerContact CustomerContact { get; set; }

        //public Currency Currency { get; set; }
    }
}

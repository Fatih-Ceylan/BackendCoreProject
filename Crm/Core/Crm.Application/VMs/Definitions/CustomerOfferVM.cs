using Utilities.Core.UtilityApplication.VMs;

namespace GCrm.Application.VMs.Definitions
{
    public class CustomerOfferVM : BaseVM
    {
        public string OfferNo { get; set; }
        public string OfferSubject { get; set; }

        public DateTime OfferDate { get; set; }
        public int TotalAmount { get; set; }

        public string OfferStatus { get; set; }
        public string CreatedUser { get; set; }
    }
}

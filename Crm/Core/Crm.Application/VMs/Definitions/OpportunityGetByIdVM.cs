namespace GCrm.Application.VMs.Definitions
{
    public class OpportunityGetByIdVM : OpportunityVM
    {
        public ICollection<CustomerContactIdNameVM> OfferCustomerContacts { get; set; }

    }
}

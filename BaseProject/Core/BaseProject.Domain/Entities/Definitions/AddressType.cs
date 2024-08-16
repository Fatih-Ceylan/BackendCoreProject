namespace BaseProject.Domain.Entities.Definitions
{
    public class AddressType: B_BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CompanyAddress> CompanyAddresses { get; set; }
    }
}
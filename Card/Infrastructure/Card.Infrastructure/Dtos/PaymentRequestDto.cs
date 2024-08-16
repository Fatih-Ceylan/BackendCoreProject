using System.Xml.Serialization;

namespace Card.Infrastructure.Dtos
{
    public class PaymentRequestDto
    {
        public string MerchantId { get; set; }
        public string Password { get; set; }
        public string TerminalNo { get; set; }
        public string Pan { get; set; }
        public string Expiry { get; set; }
        public decimal? CurrencyAmount { get; set; }
        public int? CurrencyCode { get; set; }
        public string TransactionType { get; set; }
        public string TransactionId { get; set; }
        public int? NumberOfInstallments { get; set; }
        public string CardHoldersName { get; set; }
        public string Cvv { get; set; }
        public string ECI { get; set; }
        public string CAVV { get; set; }
        public string MpiTransactionId { get; set; }
        public string? OrderId { get; set; }
        public string? OrderDescription { get; set; }
        public string ClientIp { get; set; }
        public CustomItems? CustomItems { get; set; }
        public int? TransactionDeviceSource { get; set; }
        public int? DeviceType { get; set; }
        public int? Location { get; set; }
    }

    public class CustomItems
    {
        [XmlElement("Item")]
        public Item[] Items { get; set; }
    }

    public class Item
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}

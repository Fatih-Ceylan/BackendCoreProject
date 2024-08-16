using System.Xml.Serialization;

namespace Card.Application.VMs
{
    [XmlRoot("VposRequest")]
    public class PaymentRequestVM
    {
        //Üye işyeri numarası
        public string MerchantId { get; set; } 
        public string Password { get; set; }

        //ÜİY için tanımlanmış mevcut terminallerden herhangi birinin terminal numarası iletilmelidir.Ör: VB007000,…
        public string TerminalNo { get; set; }

        //Kredi kart numarası bilgisi
        public string Pan { get; set; }

        //Kredi kartı son kullanma tarihi bilgisi Format: YYYYMM
        public string Expiry { get; set; }

        //İşlem tutar bilgisi 
        public decimal? CurrencyAmount { get; set; }

        //TL:949 v.b
        public int? CurrencyCode { get; set; }

        //Cancel -> İptal
        //Refund -> İade
        //Auth -> Ön Prov.
        //Capture -> Ön Prov. Kapama
        //Reversal -> Teknik İptal
        //CampaignSearch
        //BatchClosedSuccessSearch
        //SurchargeSearch
        //VFTSale -> Vade Farklı Satış
        //VFTSearch -> Vade Farklı Sorgu
        //TKSale -> Tarım Kart Eşit Taksitli Satış
        //TKFlexSale -> Tarım Kart Esnek Taksitli
        //Satış
        //PointSale -> Puan harcama
        //PointSearch -> Puan Sorgu
        //CardTest -> Kart Kontrol
        public string TransactionType { get; set; }

        //Benzesiz (Unique) İşlem numara bilgisi 
        public string TransactionId { get; set; }

        //02,04,07,12 v.b.
        public int? NumberOfInstallments { get; set; }
        public string CardHoldersName { get; set; }
        public string Cvv { get; set; }

        //3D secure işlemin sonucu Örn: Visa:05,06,07  MasterCard:01,02,03 Troy:01,02,03

        public string ECI { get; set; }

        //MPI tarafından 3D Secure işlemin sonucunda gönderilen alan

        public string CAVV { get; set; }

        //İşlemin Mpi tarafındaki TransactionId numarası.Bu
        //değer VPOS tarafından işlemin 3d bilgilerini kontrol
        //etmek için kullanılır.
        //Enrollment(VEReq) isteği sırasında iletilen tekil
        //VerifyEnrollmentRequestId değeri, sanal POS a
        //istek iletilirken, MpiTransactionId alanına
        //setlenmelidir.
        //!!3D Secure aşamasında gönderilen VerifyEnrollmentRequest değeri bu alana setlenmelidir
        public string MpiTransactionId { get; set; }
        public string? OrderId { get; set; }

        //İşlemin MailOrder ya da ECommerce olduğu belirtilir.
        //Tüm provizyon isteklerinde gönderilmesi zorunludur.
        //MailOrder işlem yetkiye bağlıdır ve işlem yetkisi
        //yoksa sanalpos tarafından işlem reddeilecektir.
        //MailOrder isteklerde ECI ve CAVV değerleri
        //gönderilmemelidir. ECI ve CAVV değeri sadece 3D
        //ECommerce işlemlerde gönderilmelidir
        //0:ECommerce 1:MailOrder
        public string? OrderDescription { get; set; }
        public string ClientIp { get; set; }
        public CustomItems? CustomItems { get; set; }
        public string TransactionDeviceSource { get; set; }
        public string? DeviceType { get; set; }
        public string? Location { get; set; }
    }

    // CustomItems sınıfı, XML dosyasındaki <CustomItems> öğesini temsil eder
    public class CustomItems
    {
        [XmlElement("Item")]
        public Item[] Items { get; set; }
    }

    // Item sınıfı, XML dosyasındaki her <Item> öğesini temsil eder
    public class Item
    {
        // XML dosyasındaki "name" özniteliğini temsil eden bir özellik
        [XmlAttribute("name")]
        public string Name { get; set; }

        // XML dosyasındaki "value" özniteliğini temsil eden bir özellik
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}

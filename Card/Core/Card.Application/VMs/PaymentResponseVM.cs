using System.Xml.Serialization;

namespace Card.Application.VMs
{
    [XmlRoot("VposResponse")]
    public class PaymentResponseVM
    {
        public string MerchantId { get; set; }  
        public string TransactionType { get; set; }
        public string TransactionId { get; set; }
        public string OrderId { get; set; }

        //Başarılı :0000, Başarısız :1105 v.b
        public string ResultCode { get; set; } 
        public string ResultDetail { get; set; }

        //Banka tarafından işlemin cevabında dönülen kod
        public string AuthCode { get; set; } 

        //yyyymmddhhmmss (20220427134503) formatında olacaktır
        public string HostDate { get; set; } 

        //İşlemin bank tarafındaki referans numarası 
        public string Rrn { get; set; }
        public string CurrencyAmount { get; set; }
        public string CurrencyCode { get; set; }

        //3D Secure işlem tipi   NonSecure = 1, Secure = 2, HalfSecure = 3
        public string ThreeDSecureType { get; set; }

        //İşlem sonucunda kazanılan puan bilgisi 
        public string GainedPoint { get; set; }

        //İşlem sonucunda kalan puan bilgisi
        public string TotalPoint { get; set; }
        public string BatchNo { get; set; }
        public string TLAmount { get; set; }
    }
}

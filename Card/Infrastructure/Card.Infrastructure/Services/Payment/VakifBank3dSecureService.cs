using Card.Application.Abstractions.Services.Payment;
using Card.Application.Features.Commands.Definitions.Payment._3DSecure;
using System.Globalization;
using System.Xml;

namespace Card.Infrastructure.Services.Payment
{
    public class VakifBank3dSecureService : IVakifBank3dSecureService
    {
        readonly HttpClient _httpClient;

        public VakifBank3dSecureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Create3dSecureResponse> ThreeDGatewayRequest(Create3dSecureRequest request)
        {
            try
            {
                string merchantId = request.MerchantId;
                string merchantPassword = request.Password;
                string enrollmentUrl = "https://3dsecuretest.vakifbank.com.tr/MPIAPI/MPI_Enrollment.aspx";

                var httpParameters = new Dictionary<string, string>();
                httpParameters.Add("Pan", request.Pan);
                httpParameters.Add("ExpiryDate", request.ExpiryDate);
                httpParameters.Add("PurchaseAmount", request.PurchaseAmount.ToString("N2", new CultureInfo("en-US")));
                httpParameters.Add("Currency", request.Currency.ToString());//TL 949 | EURO 978 | Dolar 840

                /*
                 * Visa 100
                 * Master Card 200
                 * American Express 300
                */
                httpParameters.Add("BrandName", request.BrandName);
                httpParameters.Add("VerifyEnrollmentRequestId", request.OrderNumber);//sipariş numarası
                httpParameters.Add("SessionInfo", "1");//banka dökümanları sabit bir değer
                httpParameters.Add("MerchantID", merchantId);
                httpParameters.Add("MerchantPassword", merchantPassword);
                httpParameters.Add("SuccessUrl", request.SuccessUrl.ToString());
                httpParameters.Add("FailureUrl", request.FailureUrl.ToString());

                string installment = request.InstallmentCount.ToString();
                if (request.InstallmentCount < 2)
                    installment = string.Empty;//0 veya 1 olması durumunda taksit bilgisini boş gönderiyoruz

                httpParameters.Add("InstallmentCount", installment);

                var response = await _httpClient.PostAsync(enrollmentUrl, new FormUrlEncodedContent(httpParameters));
                string responseContent = await response.Content.ReadAsStringAsync();

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(responseContent);
                var statusNode = xmlDocument.SelectSingleNode("IPaySecure/Message/VERes/Status");
                if (statusNode.InnerText != "Y")
                {
                    var messageErrorNode = xmlDocument.SelectSingleNode("IPaySecure/ErrorMessage");
                    var messageErrorCodeNode = xmlDocument.SelectSingleNode("IPaySecure/MessageErrorCode");

                    return new()
                    {
                        ErrorCode = messageErrorCodeNode.Value
                    };
                }

                var pareqNode = xmlDocument.SelectSingleNode("IPaySecure/Message/VERes/PaReq");
                var termUrlNode = xmlDocument.SelectSingleNode("IPaySecure/Message/VERes/TermUrl");
                var mdNode = xmlDocument.SelectSingleNode("IPaySecure/Message/VERes/MD");
                var acsUrlNode = xmlDocument.SelectSingleNode("IPaySecure/Message/VERes/ACSUrl");

                var parameters = new Dictionary<string, object>();
                parameters.Add("PaReq", pareqNode.InnerText);
                parameters.Add("TermUrl", termUrlNode.InnerText);
                parameters.Add("MD", mdNode.InnerText);

                //form post edilecek url xml response içerisinde bankadan dönüyor
                return new()
                {
                    Pareq = parameters["PaReq"].ToString(),
                    TermUrl = parameters["TermUrl"].ToString(),
                    MD = parameters["MD"].ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

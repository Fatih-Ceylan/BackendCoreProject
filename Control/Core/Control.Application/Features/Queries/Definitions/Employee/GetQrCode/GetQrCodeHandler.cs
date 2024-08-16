using MediatR;
using QRCoder;
using SixLabors.ImageSharp;

namespace GControl.Application.Features.Queries.Definitions.Employee.GetQrCode
{
    public class GetQrCodeHandler : IRequestHandler<GetQrCodeRequest, GetQrCodeResponse>
    {
        public async Task<GetQrCodeResponse> Handle(GetQrCodeRequest request, CancellationToken cancellationToken)
        {
            string userId = request.Id.ToString();
            //todo url'i appsettings'den çek
            string baseUrl = "http://localhost:5002/api/employee/getbyid";
            string qrCodeUrl = $"{baseUrl}?id={userId}";

            string qrData = qrCodeUrl;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCodeImage = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qrCodeImage.GetGraphic(20);

            using (MemoryStream ms = new MemoryStream(qrCodeBytes))
            {
                Image image = Image.Load(ms);

                using (MemoryStream msBase64 = new MemoryStream())
                {
                    image.SaveAsPng(msBase64);
                    byte[] imageBytes = msBase64.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Base64 dizeyi dönüş yaparken kullanabilirsiniz
                    return new()
                    {
                        QrCodeBase64 = base64String
                    };
                }
            }
        }
    }
}

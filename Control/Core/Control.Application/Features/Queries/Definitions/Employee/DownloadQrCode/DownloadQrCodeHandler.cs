using MediatR;
using QRCoder;
using SixLabors.ImageSharp;

namespace GControl.Application.Features.Queries.Definitions.Employee.DownloadQrCode
{
    public class DownloadQrCodeHandler : IRequestHandler<DownloadQrCodeRequest, DownloadQrCodeResponse>
    {

        public async Task<DownloadQrCodeResponse> Handle(DownloadQrCodeRequest request, CancellationToken cancellationToken)
        {
            string userId = request.Id.ToString();
            //todo appsettings'den çek
            string baseUrl = "http://localhost:5002/api/employee/getbyid";
            string qrCodeUrl = $"{baseUrl}/{userId}";

            string qrData = qrCodeUrl;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCodeImage = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qrCodeImage.GetGraphic(20);

            using (MemoryStream ms = new MemoryStream(qrCodeBytes))
            {
                Image image = Image.Load(ms);

                string filePath = $"wwwroot/qrcode_{request.Id}.png";
                image.Save(filePath);
            }

            return new DownloadQrCodeResponse
            {
                DownloadQrCode = qrCodeUrl
            };
        }
    }
}

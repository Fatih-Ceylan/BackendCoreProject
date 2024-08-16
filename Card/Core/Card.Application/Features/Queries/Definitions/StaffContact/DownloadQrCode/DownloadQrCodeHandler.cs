using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using QRCoder;
using Image = SixLabors.ImageSharp.Image;

namespace Card.Application.Features.Queries.Definitions.StaffContact.DownloadQrCode
{
    public class DownloadQrCodeHandler : IRequestHandler<DownloadQrCodeRequest, DownloadQrCodeResponse>
    {
         IHttpContextAccessor _httpContextAccessor;
        readonly IConfiguration _configuration;

        public DownloadQrCodeHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<DownloadQrCodeResponse> Handle(DownloadQrCodeRequest request, CancellationToken cancellationToken)
        {
            var route = _httpContextAccessor?.HttpContext?.Request?.Headers?["Route-Name"];
            string userId = request.Id.ToString();
            var storageURL = _configuration["Storage:BaseStorageUrl"];
            string baseUrl = $"{storageURL}{route}/Card-userqr";
            //string baseUrl = $"http://localhost:7000/{route}/Card-userqr";
            string qrCodeUrl = $"{baseUrl}/{userId}";
             
            string qrData = qrCodeUrl;
             
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCodeImage = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qrCodeImage.GetGraphic(20);

            using (MemoryStream ms = new MemoryStream(qrCodeBytes))
            {
                Image image = Image.Load(ms);
            }

            return new DownloadQrCodeResponse
            {
                DownloadQrCode = qrCodeUrl  
            };
        }
    }
}

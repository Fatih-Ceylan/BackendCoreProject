using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QRCoder;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace GControl.Application.Features.Queries.Definitions.Location.GetQrCode
{
    public class GetQrCodeHandler : IRequestHandler<GetQrCodeRequest, GetQrCodeResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;
        readonly ILocationReadRepository _locationReadRepository;
        readonly IConfiguration _configuration;
        public GetQrCodeHandler(ILocationReadRepository locationReadRepository, ICompanyReadRepository companyReadRepository, IConfiguration configuration)
        {
            _locationReadRepository = locationReadRepository;
            _companyReadRepository = companyReadRepository;
            _configuration = configuration;
        }
        public async Task<GetQrCodeResponse> Handle(GetQrCodeRequest request, CancellationToken cancellationToken)
        {
            var locationDetail = await _locationReadRepository.GetByIdAsync(request.Id);
            var companyDetail = _companyReadRepository.GetAllDeletedStatusDesc(false);
            var matchingCompany = companyDetail.FirstOrDefault(c => c.Id == locationDetail.CompanyId);

            string logoPath = null; // Default path if no match is found
            var storageURL = _configuration["Storage:BaseStorageUrl"];
            //string ipAddress = "http://10.0.96:90/";
            if (matchingCompany != null && !string.IsNullOrEmpty(matchingCompany.LogoPath))
            {
                logoPath = matchingCompany.LogoPath; // Use the LogoPath from matched company detail
            }

            string path = logoPath != null ? $"{storageURL}{logoPath}" : null;

            // Check if logoPath is available
            bool isLogoAvailable = logoPath != null;

            string locationId = request.Id;
            var location = await _locationReadRepository.GetByIdAsync(locationId);
            LocationQRVM locationQRVM = new LocationQRVM()
            {
                Name = location.Name,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Radius = location.Radius,
                Address = location.Address,
                EntryTimeLimit = location.EntryTimeLimit,
                IsEntryTimeLimitEnabled = location.IsEntryTimeLimitEnabled,
            };

            string json = JsonConvert.SerializeObject(locationQRVM);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(json, QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCodeImage = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qrCodeImage.GetGraphic(20);

            using (MemoryStream qrCodeMs = new MemoryStream(qrCodeBytes))
            using (Image qrCode = Image.Load(qrCodeMs))
            {
                if (isLogoAvailable && path != null)
                {
                    using (var httpClient = new HttpClient())
                    {
                        var httpResponse = await httpClient.GetAsync(path);

                        if (httpResponse.IsSuccessStatusCode)
                        {
                            using (var stream = await httpResponse.Content.ReadAsStreamAsync())
                            {
                                using (Image image = Image.Load(stream))
                                {
                                    Size logoSize = new Size(qrCode.Width / 4, qrCode.Height / 4);
                                    image.Mutate(x => x.Resize(logoSize));
                                    Point position = new Point((qrCode.Width - image.Width) / 2, (qrCode.Height - image.Height) / 2);
                                    qrCode.Mutate(x => x.DrawImage(image, position, 1f));
                                }
                            }
                        }
                    }
                }

                using (MemoryStream qrCodeWithLogoMs = new MemoryStream())
                {
                    qrCode.SaveAsPng(qrCodeWithLogoMs);
                    byte[] qrCodeWithLogoBytes = qrCodeWithLogoMs.ToArray();
                    string base64String = Convert.ToBase64String(qrCodeWithLogoBytes);

                    return new GetQrCodeResponse
                    {
                        QrCodeBase64 = base64String,
                        Message = isLogoAvailable ? "Logolu QR Kodu oluşturuldu." : "Logo olmadan oluşturulan QR Kodu."
                    };
                }
            }
        }

    }
}

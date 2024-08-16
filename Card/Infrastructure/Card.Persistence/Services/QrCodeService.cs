using Card.Application.Abstractions.Services.QrCode;
using Card.Application.Features.Queries.Definitions.Order.GetStaffAndQrListByOrderId;
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using Microsoft.AspNetCore.Http;
using QRCoder;
using SixLabors.ImageSharp;

namespace Card.Persistence.Services
{
    public class QrCodeService : IQrCodeService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IStaffReadRepository _staffReadRepository;
        readonly IOrderDetailReadRepository _orderDetailReadRepository;

        public QrCodeService(IHttpContextAccessor httpContextAccessor, IStaffReadRepository staffReadRepository, IOrderDetailReadRepository orderDetailReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _staffReadRepository = staffReadRepository;
            _orderDetailReadRepository = orderDetailReadRepository;
        }

        public async Task<List<StaffAndQrListVM>> GenerateQrCode(GetStaffAndQrListByOrderIdRequest request)
        {
            var route = _httpContextAccessor?.HttpContext?.Request?.Headers?["Route-Name"];
            string baseUrl = $"http://localhost:7000/{route}/Card-userqr";

            var staffAndQrList = new List<StaffAndQrListVM>();

            foreach (var orderId in request.Ids)
            {
                var orderDetails = _orderDetailReadRepository.GetWhere(x => x.OrderId.ToString() == orderId && x.IsDeleted == false).ToList();

                foreach (var orderDetail in orderDetails)
                {
                    var staff = _staffReadRepository.GetWhere(x=>x.Id.ToString()==orderDetail.PurchasedForStaffId.ToString()).FirstOrDefault();

                    if (staff == null)
                    {
                        continue;
                    }

                    string qrCodeUrl = $"{baseUrl}/{staff.Id}";
                    string qrData = qrCodeUrl;

                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);

                    BitmapByteQRCode qrCodeImage = new BitmapByteQRCode(qrCodeData);
                    byte[] qrCodeBytes = qrCodeImage.GetGraphic(20);

                    using (MemoryStream ms = new MemoryStream(qrCodeBytes))
                    {
                        var image = SixLabors.ImageSharp.Image.Load(ms);
                        using (MemoryStream msBase64 = new MemoryStream())
                        {
                            image.SaveAsPng(msBase64);
                            byte[] imageBytes = msBase64.ToArray();
                            string base64String = Convert.ToBase64String(imageBytes);

                            staffAndQrList.Add(new StaffAndQrListVM
                            {
                                FullName = $"{staff.Name} {staff.LastName}",
                                QrCodeBase64 = base64String,
                                Url = qrCodeUrl
                            });
                        }
                    }
                }
            }

            return staffAndQrList;
        }
    }
}

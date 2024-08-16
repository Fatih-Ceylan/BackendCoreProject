using AutoMapper;
using Card.Application.Abstractions.Services.Payment;
using Card.Application.Features.Commands.Definitions.Payment.VPos;
using VakifBankVPosTest;

namespace Card.Infrastructure.Services.Payment
{
    public class VakifBankVposService : IVakifBankVposService
    {
        readonly IMapper _mapper;

        public VakifBankVposService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CreatePaymentResponse> VerifyGateway(CreatePaymentRequest request)
        {
            VposRequest vposRequest = new VposRequest();

            vposRequest.MerchantId = request.MerchantId;
            vposRequest.Password = request.Password;
            vposRequest.TerminalNo = request.TerminalNo;
            vposRequest.Pan = request.Pan;
            vposRequest.Expiry = request.Expiry;
            vposRequest.CurrencyAmount = request.CurrencyAmount;
            vposRequest.CurrencyCode = request.CurrencyCode;
            vposRequest.TransactionType = request.TransactionType;
            vposRequest.TransactionId = request.TransactionId;
            vposRequest.NumberOfInstallments = request.NumberOfInstallments;
            vposRequest.CardHoldersName = request.CardHoldersName;
            vposRequest.Cvv = request.Cvv;
            vposRequest.ECI = request.ECI;
            vposRequest.CAVV = request.CAVV;
            vposRequest.MpiTransactionId = request.MpiTransactionId;
            vposRequest.OrderId = request.OrderId;
            vposRequest.OrderDescription = request.OrderDescription;
            vposRequest.ClientIp = request.ClientIp;
            vposRequest.TransactionDeviceSource = request.TransactionDeviceSource;
            vposRequest.DeviceType = request.DeviceType;
            vposRequest.Location = request.Location;

            TransactionWebServicesSoapClient serviceRequest = new TransactionWebServicesSoapClient(endpointConfiguration: 0);

            var response = serviceRequest.ExecuteVposRequestAsync(vposRequest).Result;

            var returnresult = _mapper.Map<CreatePaymentResponse>(response);

            if (response != null)
            {
                if (response.ResultCode == "0000")
                {
                    Console.WriteLine("approve");
                }
                else
                {
                    Console.WriteLine("rejected");
                }
            }

            return returnresult;
        }
    }
}

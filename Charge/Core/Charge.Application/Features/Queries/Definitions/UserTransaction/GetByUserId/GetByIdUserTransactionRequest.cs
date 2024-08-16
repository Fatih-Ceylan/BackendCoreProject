using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.UserTransaction.GetByUserId
{
    public class GetByIdUserTransactionRequest : IRequest<GetByIdUserTransactionResponse>
    {
        public string UserId { get; set; }
    }
}

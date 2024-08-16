using MediatR;

namespace GCharge.Application.Features.Commands.Identity.AppUser.VerifyEmailToken
{
    partial class VerifyEmailTokenHandler : IRequestHandler<VerifyEmailTokenRequest, VerifyEmailTokenResponse>
    {
        public async Task<VerifyEmailTokenResponse> Handle(VerifyEmailTokenRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                Verified = true,
            };
        }
    }
}
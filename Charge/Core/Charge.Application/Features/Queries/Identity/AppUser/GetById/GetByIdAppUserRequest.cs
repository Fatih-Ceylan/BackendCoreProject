using MediatR;

namespace GCharge.Application.Features.Queries.Identity.AppUser.GetById
{
    public class GetByIdAppUserRequest : IRequest<GetByIdAppUserResponse>
    {
        public string Id { get; set; }
    }
}
using MediatR;
using Utilities.Core.UtilityApplication.DTOs.File;

namespace GCharge.Application.Features.Commands.Identity.AppUser.Update
{
    public class UpdateAppUserRequest : IRequest<UpdateAppUserResponse>
    {
        public string Id { get; set; }

        public List<FileOptionDTO>? FileOptions { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

    }
}
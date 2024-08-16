using MediatR;

namespace BaseProject.Application.Features.Queries.Identity.AppUser.GetAllAppUserLicenses
{
    public class GetAllAppUserLicensesRequest : IRequest<GetAllAppUserLicensesResponse>
    {
        public string AppUserId { get; set; }

        public List<string> LicenseIds { get; set; }

    }
}
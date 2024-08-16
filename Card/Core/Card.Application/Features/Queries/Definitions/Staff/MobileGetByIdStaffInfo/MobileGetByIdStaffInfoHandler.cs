using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Queries.Definitions.Staff.MobileGetByIdStaffInfo
{
    public class MobileGetByIdStaffInfoHandler : IRequestHandler<MobileGetByIdStaffInfoRequest, MobileGetByIdStaffInfoResponse>
    {
        readonly IStaffReadRepository _staffReadRepository;

        public MobileGetByIdStaffInfoHandler(IStaffReadRepository staffReadRepository)
        {
            _staffReadRepository = staffReadRepository;
        }
        public async Task<MobileGetByIdStaffInfoResponse> Handle(MobileGetByIdStaffInfoRequest request, CancellationToken cancellationToken)
        {
            var tokenParts = request.Token.Split('@');
            var userId = tokenParts[0];
            var expirationDate = DateTime.ParseExact(tokenParts[1], "dd.MM.yyyy HH:mm:ss", null);

            var staff = await _staffReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new LoginVM
                           {
                               Id = c.Id.ToString(),
                               UserName = c.UserName,
                               Password = c.Password,
                               Token = c.Token

                           }).FirstOrDefaultAsync();

            if (staff != null && staff.Token == request.Token && expirationDate > DateTime.Now)
            {
                var relatedList = await _staffReadRepository.GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                    .Include(c => c.StaffFiles)
                    .Select(c => new MobileRelatedListByStaffIdVM
                    {
                        Id = c.Id.ToString(),
                        Email = c.Email,
                        Title = c.Title,
                        Name = c.Name,
                        LastName = c.LastName,
                        CreatedDate = c.CreatedDate,
                        ProfilePicturePath = c.ProfilePicturePath,
                        Ibans = c.Ibans.Where(x => x.StaffId == c.Id && x.IsDeleted == false).Select(x => new IbanVM
                        {
                            Id = x.Id.ToString(),
                            IbanNo = x.IbanNo,
                        }).ToList(),
                        PhoneNumbers = c.PhoneNumbers.Where(p => p.StaffId == c.Id && p.IsDeleted == false).Select(p => new PhoneNumberVM
                        {
                            Id = p.Id.ToString(),
                            Number = p.Number
                        }).ToList(),
                        PhoneNumber = c.PhoneNumber,
                        SocialMediaUrls = c.SocialMediaUrls
                                            .Where(smu => smu.StaffId == c.Id && smu.IsDeleted == false)
                                            .GroupBy(smu => smu.StaffId)
                                            .Select(group => new MobileCustomSocialMediaUrlVM
                                            {
                                                Instagrams = group.Where(smu => smu.SocialMedia.Name == "Instagram").Select(smu => new SocialMediaUrlVM
                                                {
                                                    SocialMediaId = smu.SocialMedia.Id.ToString(),
                                                    SocialMediaName = smu.SocialMedia.Name,
                                                    UrlPath = smu.UrlPath,
                                                    Id = smu.Id.ToString(),
                                                    StaffId = smu.StaffId.ToString(),
                                                }).ToList(),
                                                Linkedins = group.Where(smu => smu.SocialMedia.Name == "Linkedin").Select(smu => new SocialMediaUrlVM
                                                {
                                                    SocialMediaId = smu.SocialMedia.Id.ToString(),
                                                    SocialMediaName = smu.SocialMedia.Name,
                                                    UrlPath = smu.UrlPath,
                                                    Id = smu.Id.ToString(),
                                                    StaffId = smu.StaffId.ToString(),
                                                }).ToList(),
                                                Facebooks = group.Where(smu => smu.SocialMedia.Name == "Facebook").Select(smu => new SocialMediaUrlVM
                                                {
                                                    SocialMediaId = smu.SocialMedia.Id.ToString(),
                                                    SocialMediaName = smu.SocialMedia.Name,
                                                    UrlPath = smu.UrlPath,
                                                    Id = smu.Id.ToString(),
                                                    StaffId = smu.StaffId.ToString(),
                                                    StaffName = $"{smu.Staff.Name} {smu.Staff.LastName}"
                                                }).ToList(),
                                                Pinterests = group.Where(smu => smu.SocialMedia.Name == "Pinterest").Select(smu => new SocialMediaUrlVM
                                                {
                                                    SocialMediaId = smu.SocialMedia.Id.ToString(),
                                                    SocialMediaName = smu.SocialMedia.Name,
                                                    UrlPath = smu.UrlPath,
                                                    Id = smu.Id.ToString(),
                                                    StaffId = smu.StaffId.ToString(),
                                                }).ToList(),
                                                Twitters = group.Where(smu => smu.SocialMedia.Name == "Twitter").Select(smu => new SocialMediaUrlVM
                                                {
                                                    SocialMediaId = smu.SocialMedia.Id.ToString(),
                                                    SocialMediaName = smu.SocialMedia.Name,
                                                    UrlPath = smu.UrlPath,
                                                    Id = smu.Id.ToString(),
                                                    StaffId = smu.StaffId.ToString(),
                                                }).ToList(),
                                                WebSites = group.Where(smu => smu.SocialMedia.Name == "Web Site").Select(smu => new SocialMediaUrlVM
                                                {
                                                    SocialMediaId = smu.SocialMedia.Id.ToString(),
                                                    SocialMediaName = smu.SocialMedia.Name,
                                                    UrlPath = smu.UrlPath,
                                                    Id = smu.Id.ToString(),
                                                    StaffId = smu.StaffId.ToString(),
                                                }).ToList(),
                                            }).ToList(),
                        Description = c.Description,
                        UserName = c.UserName,
                        Password = c.Password,
                        Token = c.Token,
                        StaffFields = c.StaffFields.Where(sf => sf.StaffId == c.Id && sf.IsDeleted == false).Select(sf => new StaffFieldVM
                        {
                            Id = sf.Id.ToString(),
                            RowNumber = sf.RowNumber,
                            FieldId = sf.FieldId.ToString(),
                            FieldName = sf.Field.Name.ToString(),
                            StaffId = c.Id.ToString()

                        }).ToList(),
                        Files = c.StaffFiles
                                                         .Where(sf => sf.IsDeleted == false)
                                                         .Select(sf => new StaffFileVM
                                                         {
                                                             Id = sf.Id.ToString(),
                                                             FileName = sf.FileName,
                                                             PathOrContainerName = sf.Path,
                                                             Storage = sf.Storage,
                                                             StaffId = c.Id.ToString()
                                                         }).ToList(),
                    }).FirstOrDefaultAsync();

                int socialMediaUrlListCount = 0;
                if (relatedList != null && relatedList.SocialMediaUrls != null)
                {
                    foreach (var mobileCustomSocialMediaUrl in relatedList.SocialMediaUrls)
                    {
                        if (mobileCustomSocialMediaUrl.Instagrams != null && mobileCustomSocialMediaUrl.Instagrams.Any())
                            socialMediaUrlListCount++;

                        if (mobileCustomSocialMediaUrl.Linkedins != null && mobileCustomSocialMediaUrl.Linkedins.Any())
                            socialMediaUrlListCount++;

                        if (mobileCustomSocialMediaUrl.Facebooks != null && mobileCustomSocialMediaUrl.Facebooks.Any())
                            socialMediaUrlListCount++;

                        if (mobileCustomSocialMediaUrl.Pinterests != null && mobileCustomSocialMediaUrl.Pinterests.Any())
                            socialMediaUrlListCount++;

                        if (mobileCustomSocialMediaUrl.Twitters != null && mobileCustomSocialMediaUrl.Twitters.Any())
                            socialMediaUrlListCount++;

                        if (mobileCustomSocialMediaUrl.WebSites != null && mobileCustomSocialMediaUrl.WebSites.Any())
                            socialMediaUrlListCount++;
                    }
                }

                return new MobileGetByIdStaffInfoResponse
                {
                    RelatedList = relatedList,
                    SocialMediaUrlListCount = socialMediaUrlListCount,
                    Message = CommandResponseMessage.Success.ToString(),
                    StatusCode="200"
                };
            }
            else if (staff != null && staff.Token != request.Token)
            {
                return new MobileGetByIdStaffInfoResponse { Message = CommandResponseMessage.TokenNotMatchedError.ToString(), StatusCode = "403" };
            }
            else if (staff != null && expirationDate <= DateTime.Now)
            {
                return new MobileGetByIdStaffInfoResponse { Message = CommandResponseMessage.SessionExpired.ToString(), StatusCode = "419" };
            }
            else
            {
                return new MobileGetByIdStaffInfoResponse { Message = CommandResponseMessage.UserNotFound.ToString(), StatusCode = "404" };
            }
        }
    }
}

using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Queries.Definitions.Staff.GetByIdStaffInfo
{
    public class GetByIdStaffInfoHandler : IRequestHandler<GetByIdStaffInfoRequest, GetByIdStaffInfoResponse>
    {
        readonly IStaffReadRepository _staffReadRepository;

        public GetByIdStaffInfoHandler(IStaffReadRepository staffReadRepository)
        {
            _staffReadRepository = staffReadRepository;
        }
        public  async Task<GetByIdStaffInfoResponse> Handle(GetByIdStaffInfoRequest request, CancellationToken cancellationToken)
        { 
            if (request.Id == null || !Guid.TryParse(request.Id, out var idGuid))
            {
                return new GetByIdStaffInfoResponse
                {
                    Message = CommandResponseMessage.InvalidId.ToString(),
                    StatusCode = "400"
                };
            }
             
            var user = _staffReadRepository.GetWhere(c => c.Id == idGuid, false)?.Select(c => new GetRelatedListByStaffIdVM
            {
                Id = c.Id.ToString(),
                Email = c.Email,
                Title = c.Title,
                Name = c.Name,
                LastName = c.LastName,
                CreatedDate = c.CreatedDate,
            }).ToList();

            if (user == null)
            {
                return new GetByIdStaffInfoResponse
                {
                    Message = CommandResponseMessage.UserNotFound.ToString(),
                    StatusCode = "404"
                };
            }
             
            var relatedList = await _staffReadRepository.GetWhere(c => c.Id == idGuid, false)
                                            .Include(c => c.StaffFiles)
                                            .Select(c => new GetRelatedListByStaffIdVM
                                            {
                                                Id = c.Id.ToString(),
                                                Email = c.Email,
                                                Title = c.Title,
                                                Name = c.Name,
                                                LastName = c.LastName,
                                                BranchId = c.BranchId.ToString(),
                                                CompanyId = c.CompanyId.ToString(),
                                                BranchName = c.Branch.Name,
                                                CompanyName = c.Branch.Company.Name,
                                                CreatedDate = c.CreatedDate,
                                                Ibans = c.Ibans.Where(x => x.StaffId == c.Id && x.IsDeleted == false).Select(x => new IbanVM
                                                {
                                                    Id = x.Id.ToString(),
                                                    IbanNo = x.IbanNo,
                                                    StaffId = c.Id.ToString(),
                                                    StaffName = $"{c.Name} {c.LastName}"
                                                }).ToList(),
                                                PhoneNumbers = c.PhoneNumbers.Where(p => p.StaffId == c.Id && p.IsDeleted == false).Select(p => new PhoneNumberVM
                                                {
                                                    Id = p.Id.ToString(),
                                                    Number = p.Number,
                                                    StaffId = c.Id.ToString(),
                                                    StaffName = $"{c.Name} {c.LastName}"
                                                }).ToList(),
                                                SocialMediaUrls = c.SocialMediaUrls
                                                .Where(smu => smu.StaffId == c.Id && smu.IsDeleted == false)
                                                .GroupBy(smu => smu.StaffId)
                                                .Select(group => new CustomSocialMediaUrlVM
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
                                                ProfilePicturePath = c.ProfilePicturePath,
                                                UserName = c.UserName,
                                                Password = c.Password,
                                                Token = c.Token,
                                                PhoneNumber = c.PhoneNumber,
                                                StaffFields = c.StaffFields.Where(sf => sf.StaffId == c.Id && sf.IsDeleted == false).Select(sf => new StaffFieldVM
                                                {
                                                    Id = sf.Id.ToString(),
                                                    RowNumber = sf.RowNumber,
                                                    FieldName = sf.Field.Name,
                                                    FieldId = sf.FieldId.ToString(),
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

            if (relatedList == null)
            {
                return new GetByIdStaffInfoResponse
                {
                    Message = CommandResponseMessage.NotFound.ToString(),
                    StatusCode="404"
                };
            }
             
            int socialMediaUrlListCount = 0;
            if (relatedList.SocialMediaUrls != null)
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
             
            return new GetByIdStaffInfoResponse
            {
                RelatedList = relatedList,
                SocialMediaUrlListCount = socialMediaUrlListCount,
                Message = CommandResponseMessage.Success.ToString(),
                StatusCode="200"
            };
        }
    }
}

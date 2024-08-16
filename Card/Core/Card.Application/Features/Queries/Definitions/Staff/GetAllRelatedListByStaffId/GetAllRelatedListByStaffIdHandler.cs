using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.Staff.GetAllRelatedListByStaffId
{
    public class GetAllRelatedListByStaffIdHandler : IRequestHandler<GetAllRelatedListByStaffIdRequest, GetAllRelatedListByStaffIdResponse>
    {
        readonly IStaffReadRepository _staffReadRepository;

        public GetAllRelatedListByStaffIdHandler(IStaffReadRepository staffReadRepository)
        {
            _staffReadRepository = staffReadRepository;
        }

        public Task<GetAllRelatedListByStaffIdResponse> Handle(GetAllRelatedListByStaffIdRequest request, CancellationToken cancellationToken)
        {
            var query = _staffReadRepository.GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                                            .Include(c => c.StaffFiles)
                                            .Select(c => new GetRelatedListByStaffIdVM
                                            {
                                                Id = c.Id.ToString(),
                                                Email = c.Email,
                                                Title = c.Title,
                                                Name = c.Name,
                                                LastName = c.LastName,
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
                                                StaffFields = c.StaffFields
                                                               .Where(sf => sf.StaffId == c.Id && sf.IsDeleted == false)
                                                               .Select(sf => new StaffFieldVM
                                                               {
                                                                   Id = sf.Id.ToString(),
                                                                   RowNumber = sf.RowNumber,
                                                                   FieldName = sf.Field.Name,
                                                                   FieldId = sf.FieldId.ToString(),
                                                                   StaffId = c.Id.ToString(),
                                                                   BranchId = sf.BranchId.ToString(),
                                                                   BranchName = sf.Branch.Name,
                                                                   CompanyId = sf.CompanyId.ToString(),
                                                                   CompanyName = sf.Branch.Company.Name.ToString()

                                                               }).ToList(),
                                                Files = c.StaffFiles
                                                         .Where(sf => sf.IsDeleted == false && !sf.Path.Contains("Staff-ProfilePictures"))
                                                         .Select(sf => new StaffFileVM
                                                         {
                                                             Id = sf.Id.ToString(),
                                                             FileName = sf.FileName,
                                                             PathOrContainerName = sf.Path,
                                                             Storage = sf.Storage,
                                                             StaffId = c.Id.ToString()
                                                         }).ToList(),
                                                BranchId = c.BranchId.ToString(),
                                                BranchName = c.Branch.Name,
                                                CompanyId = c.CompanyId.ToString(),
                                                CompanyName = c.Branch.Company.Name,
                                            });

            var totalCount = query.Count();
            var relatedList = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllRelatedListByStaffIdResponse
            {
                RelatedList = relatedList,
            });
        }
    }
}

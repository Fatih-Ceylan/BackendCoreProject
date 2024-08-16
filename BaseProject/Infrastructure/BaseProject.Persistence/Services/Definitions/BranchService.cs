using BaseProject.Application.Abstractions.Services.Definitions;
using BaseProject.Application.DTOs.Definitions.Branch;
using BaseProject.Application.Repositories.ReadRepository.Definitions;

namespace BaseProject.Persistence.Services.Definitions
{
    public class BranchService : IBranchService
    {
        readonly IBranchReadRepository _branchReadRepository;
        readonly ICountryReadRepository _countryReadRepository;

        public BranchService(IBranchReadRepository branchReadRepository, ICountryReadRepository countryReadRepository)
        {
            _branchReadRepository = branchReadRepository;
            _countryReadRepository = countryReadRepository;
        }

        public async Task<List<BranchDTO>> GetAllActiveBranches()
        {
            var branches = _branchReadRepository.GetAllDeletedStatus(false)
                                                  .Select(b => new BranchDTO
                                                  {
                                                      Id = b.Id.ToString(),
                                                      Name = b.Name,
                                                      CompanyId = b.CompanyId.ToString(),
                                                      CompanyName = b.Company.Name,
                                                      //FullAddress = b.Company.FullAddress,
                                                      CityId = b.CityId.ToString(),
                                                      DistrictId = b.DistrictId.ToString(),
                                                      CountryId = b.CountryId.ToString(),

                                                  }).ToList();

            return branches;
        }

        public async Task<List<BranchDTO>> GetAllActiveBranchesWithIds(string companyId, string branchId)
        {
            var branchQuery = _branchReadRepository.GetAllDeletedStatus(false);
            var countryQuery = _countryReadRepository.GetAllDeletedStatus(false);
            List<BranchDTO> result = new();

            if (branchId == "SelectAll")
            {
                result = branchQuery.Where(b => b.CompanyId.ToString() == companyId)
                                   .Select(b => new BranchDTO
                                   {
                                       Id = b.Id.ToString(),
                                       Name = b.Name,
                                       CompanyId = b.CompanyId.ToString(),
                                       CompanyName = b.Company.Name,
                                       //FullAddress = b.Company.FullAddress,
                                       CityId = b.CityId.ToString(),
                                       DistrictId = b.DistrictId.ToString(),
                                       CountryId = b.CountryId.ToString(),
                                       CityName = b.District.City.Name,
                                       CountryName = countryQuery.Where(x => x.Idc.ToString() == b.CountryId.ToString()).Select(x => x.Name).FirstOrDefault(),
                                       DistrictName = b.District.Name
                                   }).ToList();
            }

            else
            {
                result = branchQuery.Where(b => b.CompanyId.ToString() == companyId && b.Id.ToString() == branchId)
                                   .Select(b => new BranchDTO
                                   {
                                       Id = b.Id.ToString(),
                                       Name = b.Name,
                                       CompanyId = b.CompanyId.ToString(),
                                       CompanyName = b.Company.Name,
                                       //FullAddress = b.Company.FullAddress,
                                       CityId = b.CityId.ToString(),
                                       DistrictId = b.DistrictId.ToString(),
                                       CountryId = b.CountryId.ToString(),
                                       CityName = b.District.City.Name,
                                       CountryName = countryQuery.Where(x => x.Idc.ToString() == b.CountryId.ToString()).Select(x => x.Name).FirstOrDefault(),
                                       DistrictName = b.District.Name
                                   }).ToList();
            }

            return result;
        }

        public async Task<BranchDTO> GetAllActiveBranchWithIds(string companyId, string branchId)
        {
            var countryQuery = _countryReadRepository.GetAllDeletedStatus(false);
            var branch = _branchReadRepository
                                  .GetWhere(b => b.CompanyId.ToString() == companyId && b.Id.ToString() == branchId, false)
                                  .Select(b => new BranchDTO
                                  {
                                      Id = b.Id.ToString(),
                                      Name = b.Name,
                                      CompanyId = b.CompanyId.ToString(),
                                      CompanyName = b.Company.Name,
                                      //FullAddress = b.Company.FullAddress,
                                      CityId = b.CityId.ToString(),
                                      DistrictId = b.DistrictId.ToString(),
                                      CountryId = b.CountryId.ToString(),
                                      CityName = b.District.City.Name,
                                      CountryName = countryQuery.Where(x => x.Idc.ToString() == b.CountryId.ToString()).Select(x => x.Name).FirstOrDefault(),
                                      DistrictName = b.District.Name,
                                      TaxNo = b.Company.TaxNo,
                                      TaxOffice = b.Company.TaxOffice
                                  }).FirstOrDefault();

            return branch;
        }
    }
}

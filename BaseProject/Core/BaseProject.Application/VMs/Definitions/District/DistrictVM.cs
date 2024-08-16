namespace BaseProject.Application.VMs.Definitions.District
{
    public class DistrictVM
    {
        public int Id { get; set; }
        
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public string Name { get; set; }
    }
}
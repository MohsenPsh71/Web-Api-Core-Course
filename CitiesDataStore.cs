using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto() { Id = 1, Name = "Tehran",
                Description ="This  is My City" },
                 new CityDto() { Id = 2, Name = "Shiraz",
                Description ="This  is My City" },
                  new CityDto() { Id = 3, Name = "Ahwaz",
                Description ="This  is My City" },
            };
        }
    }
}

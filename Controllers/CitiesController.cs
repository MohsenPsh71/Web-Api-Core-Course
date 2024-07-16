using CityInfo.API.Models;
using CityInfo.API.Repositoties;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Core_Course.Models;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CitiesController: ControllerBase
    {
       private readonly ICityInfoRepository _cityInfoRepository;    

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository ?? 
                throw new ArgumentNullException(nameof(cityInfoRepository));        
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities()
        {
            var Cities =await _cityInfoRepository.GetCitiesAsync();

            var result = new List<CityWithoutPointOfInterestDto>();

            foreach (var city in Cities)
            {
                result.Add(new CityWithoutPointOfInterestDto()
                {
                    Id = city.Id,
                    Description =  city.Description,
                    Name=city.Name
                });
            }

            return Ok(result);
           // return Ok(citiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {

            return Ok();
   
        }

    }
}

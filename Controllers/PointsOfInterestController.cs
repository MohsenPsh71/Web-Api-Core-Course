using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    //  /api/cities/3/pointsofinterest
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>>
            GetPointsOfInterest(int cityId)
        {
            var city =
                CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(
            int cityId, int pointOfInterestId
            )
        {
            var city =
                CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var point = city.PointsOfInterest
                .FirstOrDefault(p => p.Id == pointOfInterestId);

            if (point == null)
            {
                return NotFound();
            }

            return Ok(point);
        }

        #region  Post
        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(
          int cityId,
          PointOfInterestForCreationDto pointOfInterest
          )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.current
                .Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxpointOfInterestId = CitiesDataStore.current.Cities
                .SelectMany(c => c.PointsOfInterest)
                .Max(p => p.Id);

            var createPoint = new PointOfInterestDto()
            {
                Id = ++maxpointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(createPoint);



            return CreatedAtAction("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = createPoint.Id

                },
                createPoint
                );
        }
        #endregion

        #region Edit
        [HttpPut("{pontiOfInterestId}")]
        public ActionResult UpdatePointOfInterest(int cityId,
            int pontiOfInterestId,
            PointOfInterestForUpdateDto pointOfInterest)
        {
            //find  city
            var city = CitiesDataStore.current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();

            // find point of interest
            var point = city.PointsOfInterest
                .FirstOrDefault(p => p.Id == pontiOfInterestId);
            if (point == null)
                return NotFound();

            point.Name = pointOfInterest.Name;
            point.Description = pointOfInterest.Description;

            return NoContent();

        }
        #endregion
    }
}


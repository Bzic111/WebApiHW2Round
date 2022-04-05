using Microsoft.AspNetCore.Mvc;

namespace WebApiHW.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ForecastHolder _forecastHolder;

        public WeatherForecastController(ForecastHolder holder)
        {
            _forecastHolder = holder;
        }

        #region Create

        [HttpPost("api/create/date/{date}/tempC/{tempC}/summary/{summary}")]
        public IActionResult Create([FromRoute] string date, [FromRoute] int tempC, [FromRoute] string summary)
        {
            return Ok(_forecastHolder.AddForecast(new(date, tempC, summary)));
        }

        #endregion

        #region Read

        [HttpGet("api/find/date/{date}")]
        public IActionResult Read([FromRoute] string date)
        {
            return Ok(_forecastHolder.GetForecastByDate(date));
        }

        #endregion

        #region Update

        [HttpPatch("api/change/date/{date}/tempC/{tempC}/summary/{summary}")]
        public IActionResult Update([FromRoute] string date, [FromRoute] int tempC, [FromRoute] string summary)
        {
            return Ok(_forecastHolder.UpdateForecast(date, tempC, summary));
        }

        #endregion

        #region Delete

        [HttpDelete("api/delete_by_date/{date}")]
        public IActionResult DeleteByDate([FromRoute] string date)
        {
            return Ok(_forecastHolder.DeleteForecast(date));
        }

        [HttpDelete("api/delete_by_id/{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            return Ok(_forecastHolder.DeleteForecast(id));
        }

        #endregion
    }
}
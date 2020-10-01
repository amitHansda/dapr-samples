using System;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DaprExample.StateStore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StatestoreController : ControllerBase
    {
        private readonly ILogger<StatestoreController> _logger;
        private readonly DaprClient _daprClient;

        public StatestoreController(ILogger<StatestoreController> logger,DaprClient daprClient)
        {
            this._logger = logger;
            this._daprClient = daprClient;
        }

        [HttpPost]
        public async Task<IActionResult> SetWeatherDataAsync([FromBody]WeatherForecast model)
        {
            
            await _daprClient.SaveStateAsync<WeatherForecast>("statestore", model.Key, model);
            _logger.LogInformation("State Saved");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeatherDataAsync([FromBody]WeatherRequest model)
        {
            var weatherdetails = await _daprClient.GetStateAsync<WeatherForecast>("statestore", model.Key);
            return Ok(weatherdetails);
        }
    }
}

using System.Threading.Tasks;
using Dapr.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyActor.Interfaces;

namespace MyActor.Service.WebClient.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SetDataAsync([FromQuery]string actorId,
            [FromBody]MyData model)
        {
            var actorType = "MyActor";
            var actorID = new ActorId(actorId);
            var proxy = ActorProxy.Create<IMyActor>(actorID, actorType);
            var response = await proxy.SetDataAsync(model);
            return Ok(response);
        }


        [HttpGet("{actorId}")]
        public async Task<IActionResult> GetdataAsync(string actorId)
        {
            var actorType = "MyActor";
            var actorID = new ActorId(actorId);
            var proxy = ActorProxy.Create<IMyActor>(actorID, actorType);
            var savedData = await proxy.GetDataAsync();
            return Ok(savedData);
        }
        
    }
}

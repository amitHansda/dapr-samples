using BuildingBlock;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.First.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly DaprClient _daprClient;

        public MessageController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        [HttpPost("sendfunnytopic")]
        public async Task<IActionResult> SendFunnyTopicAsync(string message)
        {
            await this._daprClient.PublishEventAsync("pubsub", "funnytopic",new Message { Content = message});
            return Ok();
        }
    }
}

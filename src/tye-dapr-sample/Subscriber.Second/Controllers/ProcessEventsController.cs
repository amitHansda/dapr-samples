using BuildingBlock;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Subscriber.Second.Controllers
{
    [ApiController]
    public class ProcessEventsController : ControllerBase
    {
        private readonly ILogger<ProcessEventsController> _logger;

        public ProcessEventsController(ILogger<ProcessEventsController> logger)
        {
            _logger = logger;
        }

        [Topic("messagebus", "serioustopic")]
        [HttpPost("serioustopic")]
        public IActionResult SeriousTopic([FromBody] Message msg)
        {
            _logger.LogInformation("Subscribed serious message:{message}", msg.Content);
            return Ok();
        }


        [Topic("messagebus", "funnytopic")]
        [HttpPost("funnytopic")]
        public IActionResult FunnyTopic([FromBody] Message msg)
        {
            _logger.LogInformation("Subscribed funny message:{message}", msg.Content);
            return Ok();
        }

    }
}

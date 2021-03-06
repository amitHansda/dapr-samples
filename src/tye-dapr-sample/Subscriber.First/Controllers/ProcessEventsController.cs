﻿using BuildingBlock;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Subscriber.First.Controllers
{
    [ApiController]
    public class ProcessEventsController : ControllerBase {
        private readonly ILogger<ProcessEventsController> _logger;

        public ProcessEventsController(ILogger<ProcessEventsController> logger)
        {
            _logger = logger;
        }
        
        [Topic("messagebus", "funnytopic")]
        [HttpPost("funnytopic")]
        public IActionResult FunnyTopic([FromBody]Message msg)
        {
            _logger.LogInformation("Subscribed funny message:{message}", msg.Content);
            return Ok();
        }

    }
}

using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplePubSub.BuildingBlock;

namespace SimplePubSub.Subscriber.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Topic("pubsub", "orderdispatched")]
        public async Task<IActionResult> SubscribeOrderDispatchedAsync(ProductOrder order)
        {
            _logger.LogInformation("{productName} is shipped for {customer}, estimated date for delivery:{estimatedDate}",
                order.ProductName, order.CustomerName, order.EstimatedDeliveryDate.ToString("dd-MMM-yyyy"));
            return Ok();
        }

    }
}

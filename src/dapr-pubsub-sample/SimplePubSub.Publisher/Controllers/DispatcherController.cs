using System.Threading.Tasks;
using Bogus;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplePubSub.BuildingBlock;

namespace SimplePubSub.Publisher.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DispatcherController : ControllerBase
    {
        private readonly ILogger<DispatcherController> _logger;
        private readonly DaprClient _daprClient;
        private readonly Faker<ProductOrder> _faker;

        public DispatcherController(ILogger<DispatcherController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
            _faker = new Faker<ProductOrder>()
                .RuleFor(x => x.CustomerName, f => f.Person.FullName)
                .RuleFor(x=> x.ProductName, f=> f.Commerce.ProductName())
                .RuleFor(x=> x.EstimatedDeliveryDate, f=> f.Date.Soon(14));
        }
        
        [HttpPost]
        public async Task<IActionResult> OrderAsync()
        {
            var order =_faker.Generate();
            await _daprClient.PublishEventAsync("pubsub", "orderdispatched", order);
            return Ok();
        }
    }
}

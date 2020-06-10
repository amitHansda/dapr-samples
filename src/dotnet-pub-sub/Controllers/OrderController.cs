using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PubSubSample.OrderManager.Domain.Models;
using RestSharp;

namespace PubSubSample.OrderManager.Controllers
{
    //Environment.GetEnvironmentVariable("DAPR_HTTP_PORT")

    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            this._logger = logger;
        }

        [HttpPost]
        [Route("api/order")]
        public async Task<IActionResult> ReceiveOrder([FromBody] Order order)
        {
            _logger.LogInformation($"Order with id {order.Id} received");


            //some validations - TBD
            var baseUrl = $"http://localhost:{Environment.GetEnvironmentVariable("DAPR_HTTP_PORT")}/v1.0";
            _logger.LogInformation($"hitting {baseUrl} ");
            
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.PostAsync(
                    $"{baseUrl}/publish/ordertopic",new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json")
                );

                _logger.LogInformation($"Order with id {order.Id} published with status {result.StatusCode}!");
            }
            return Ok();
        }

        [Topic("ordertopic")]
        [HttpPost]
        [Route("ordertopic")]
        public async Task<IActionResult> ProcessOrder([FromBody] Order order)
        {  //Process order placeholder

            _logger.LogInformation($"Order with id {order.Id} subscribed!");
            return Ok();
        }


    }
}
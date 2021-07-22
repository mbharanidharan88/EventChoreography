using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public BasketController(ILogger<BasketController> logger,
                                IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IEnumerable<int>> Get()
        {
            try
            {
                var evt = new BasketCheckoutEvent
                {
                    ItemName = "Tamil book",
                    TotalPrice = 4.5M
                };

                await _publishEndpoint.Publish(evt);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
            }



            return Enumerable.Range(1, 5).ToArray();
        }
    }
}

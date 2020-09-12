using System;
using System.Threading.Tasks;
using Framework.EF.RabbitMq;
using MicroServiceWebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:ControllerBase
    {
        private readonly IRabbitManager _rabbit;
        public OrderController(IRabbitManager rabbit)
        {
            _rabbit = rabbit;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            // Uri uri=new Uri("rabbitmq://localhost/order_queue");
            // var endPoint = await _bus.GetSendEndpoint(uri);
            // await endPoint.Send<Order>(order);
            _rabbit.Publish(order,"exchange.test","topic","*.queue.durable.#");
            return Ok("success");
        }
    }
}
using System;
using System.Threading.Tasks;
using MassTransit;
using MicroServiceWebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:ControllerBase
    {
        private readonly IBusControl _bus;
        public OrderController(IBusControl bus)
        {
            _bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            Uri uri=new Uri("rabbitmq://localhost/order_queue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send<Order>(order);
            return Ok("success");
        }
    }
}
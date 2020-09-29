using System;
using System.Threading.Tasks;
using Framework.CQRS.CommandCustomize;
using Framework.EF.Commands;
using Framework.EF.DomainEvents;
using Framework.EF.RabbitMq;
using MicroServiceWebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:ControllerBase
    {
        private readonly IEventBus _bus;
        public OrderController(IEventBus bus)
        {

            _bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateCustomerCommand command)
        {
            // Uri uri=new Uri("rabbitmq://localhost/order_queue");
            // var endPoint = await _bus.GetSendEndpoint(uri);
            // await endPoint.Send<Order>(order);
            // _rabbit.Publish(order,"exchange.test","topic","*.queue.durable.#");
            var responseCommand=await _bus.Issue(command);
            return Ok(responseCommand);
        }
    }
}
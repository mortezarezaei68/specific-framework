using System.Threading.Tasks;
using MassTransit;
using MicroserviceWebApplication2.Models;

namespace MicroserviceWebApplication2
{
    public class OrderConsumer : IConsumer<Order>
    {
        public Task Consume(ConsumeContext<Order> context)
        {
            var data = context.Message;
            return Task.CompletedTask;
        }
    }
}
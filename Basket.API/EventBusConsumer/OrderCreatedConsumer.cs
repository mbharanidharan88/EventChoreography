using EventBus.Messages.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.EventBusConsumer
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            try
            {
                await Task.Delay(2 * 1000);
                // throw new NotFiniteNumberException(); 
                var message = context.Message;
                //// await context.RespondAsync(message);

                //await context.Publish(message);

                // await _mediator.Send(message);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

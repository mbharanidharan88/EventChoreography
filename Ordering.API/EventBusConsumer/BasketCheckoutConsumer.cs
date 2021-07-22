using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Mediator;
using System;
using System.Threading.Tasks;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;

        public BasketCheckoutConsumer(IMediator mediator, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            try
            {
                await Task.Delay(2 * 1000);
                // throw new NotFiniteNumberException(); 
                var message = context.Message;
                //// await context.RespondAsync(message);

                //await context.Publish(message);

                var evt = new OrderCreatedEvent
                {
                    OrderId = Guid.NewGuid()
                };

                // await _mediator.Send(evt);
                await _publishEndpoint.Publish(evt);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
